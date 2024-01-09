using System;
using System.Collections.Generic;
using UnityEngine;
using VisualNovel.Commands;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Engine
{
    public interface INovelPlayer
    {
        bool IsPlaying { get; }
        bool IsReadyToPlay { get; }


        void Play();
        void SetStoryLine(IStoryLine storyLine, int startIndex);
    }

    public sealed class NovelPlayer : INovelPlayer
    {
        private readonly IReadOnlyDictionary<ICommand, bool> _manualNextRequiredDict;
        private readonly ICommandsManager _commandsManager;
        private IStoryLine _storyLine;
        private int _nextCmdIndex;
        private bool _isPlaying;
        private bool _isReady;


        public NovelPlayer(IReadOnlyDictionary<ICommand, bool> manualNextRequiredDict,
            ICommandsManager commandsManager)
        {
            _manualNextRequiredDict = manualNextRequiredDict;
            _commandsManager = commandsManager;
        }


        public bool IsPlaying => _isPlaying;
        public bool IsReadyToPlay => _isReady;


        public void Play()
        {
            if (!IsReadyToPlay || IsPlaying)
                throw new InvalidOperationException();

            _isPlaying = true;
            _isReady = false;

            while (true)
            {
                var cmd = _storyLine.Commands[_nextCmdIndex];
                _commandsManager.Execute(cmd);
                ++_nextCmdIndex;

                if (_manualNextRequiredDict[cmd])
                    break;
            }

            _isPlaying = false;
            _isReady = default; // this requires another dict<icommand, bool>...
        }

        public void SetStoryLine(IStoryLine storyLine, int startIndex)
        {
            _storyLine = storyLine;
            _nextCmdIndex = startIndex;
        }
    }
    public sealed class NovelController : MonoBehaviour, INovelController
    {
        [SerializeField] private SerializedInterface<ICommandsManager> _commandsManager;
        [SerializeField] private TypeMap<CommandSO, bool> _manualNextRequiredMap;

        private INovelEngine _engine;
        private IStoryLine _storyLine;
        private IEnumerator<ICommand> _storyLineEnumerator;


        private void Awake()
        {
            _engine = new NovelEngine(_commandsManager.Item);
        }

        public void GoNext()
        {
            IReadOnlyDictionary<Type, bool> dict = _manualNextRequiredMap;

            while (true)
            {
                ICommand cmd = GetNextCommand();
                _engine.ExecuteCommand(cmd);

                bool manualNextIsRequired = dict[cmd.GetType()];

                if (manualNextIsRequired)
                    break;
            }
        }


        private ICommand GetNextCommand()
        {
            if (!_storyLineEnumerator.MoveNext())
                throw new InvalidCastException("unable to move next");

            return _storyLineEnumerator.Current;
        }

        public void SetStoryLine(IStoryLine storyLine)
        {
            SetStoryLine(storyLine, 0);
        }

        public void SetStoryLine(IStoryLine storyLine, int commandIndex)
        {
            _storyLine = storyLine;
            _storyLineEnumerator?.Dispose();
            _storyLineEnumerator = storyLine.Commands.GetEnumerator();

            for (int i = 0; i < commandIndex; i++)
            {
                _storyLineEnumerator.MoveNext();
            }
        }
    }


}
