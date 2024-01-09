using System;
using System.Collections.Generic;
using UnityEngine;
using VisualNovel.Commands;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Engine
{
    public sealed class NovelController : MonoBehaviour, INovelController
    {
        [SerializeField] private SerializedDictionaryWithDefaultValue<CommandSO, int> _commandWeights;
        [SerializeField] private SerializedDictionaryWithDefaultValue<NovelPlayMode, int> _modesWeightThreshold;
        //[SerializeField] private UnityEngine.Object _novelEngineRaw;
        [SerializeField] private UnityEngine.Object _commandsManager;

        private INovelEngine _novelEngine;
        private StoryLineSO _storyLine;
        private int _currentCommandIndex;
        private NovelPlayMode _mode;


        public NovelPlayMode Mode { get => _mode; set => ChangeMode(value); }

        //private INovelEngine NovelEngine => (INovelEngine)_novelEngineRaw;
        private INovelEngine NovelEngine => _novelEngine;


        private void Awake()
        {
            _novelEngine = new NovelEngine((ICommandsManager)_commandsManager);
        }

        public void GoNext()
        {
            int threshold = _modesWeightThreshold.GetValueOrDefault(_mode);

            while (true)
            {
                CommandSO executedCmd = ExecuteNextCommand();
                int weight = _commandWeights.GetValueOrDefault(executedCmd);

                if (weight >= threshold)
                    break;
            }
        }

        public void SetStoryLine(StoryLineSO storyLine)
        {
            _storyLine = storyLine;
            _currentCommandIndex = -1;
        }

        public void SetStoryLine(StoryLineSO storyLine, int commandIndex)
        {
            _storyLine = storyLine;
            _currentCommandIndex = commandIndex;
        }

        public void InsertCommands(IEnumerable<CommandSO> commands)
        {

        }

        private void ChangeMode(NovelPlayMode value)
        {
            if (_mode == value)
                return;

            _mode = value;
        }

        private CommandSO ExecuteNextCommand()
        {
            int newIndex = _currentCommandIndex + 1;

            if (newIndex >= _storyLine.Commands.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var newCommand = _storyLine.Commands[newIndex];
            _currentCommandIndex = newIndex;
            NovelEngine.ExecuteCommand(newCommand);
            return newCommand;
        }
    }
}
