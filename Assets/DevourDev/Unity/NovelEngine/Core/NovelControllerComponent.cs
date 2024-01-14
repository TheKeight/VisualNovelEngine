using System;
using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using DevourDev.Unity.Utility.Serialization;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Core
{
    [DefaultExecutionOrder(-2000)]
    internal sealed class NovelControllerComponent : MonoBehaviour, INovelController
    {
        [SerializeField] private SerializedInterface<ICommandsManager> _commandsManager;
        [SerializeField] private TypeMap<NovelCommand, bool> _stoppingCommands;
        [SerializeField] private TypeMap<NovelCommand, bool> _blockingCommands;

        private INovelController _controller;
        private bool _goNextInputIsLocked;


        public bool CanGoNext => !_goNextInputIsLocked && _controller.CanGoNext;

        public event Action<ICommand> CommandExecuted;


        private void Awake()
        {
            var unitedDict = new DictionaryWithDefaultValue<System.Type, bool>(false);

            foreach (var kvp in _stoppingCommands)
            {
                unitedDict[kvp.Key] = kvp.Value;
            }

            foreach (var kvp in _blockingCommands)
            {
                unitedDict[kvp.Key] = kvp.Value;
            }

            _controller = new NovelController(_commandsManager.Item, unitedDict, _blockingCommands);
            _controller.CommandExecuted += OnCommandExecuted;
        }

        public void GoNext()
        {
            _controller.GoNext();
        }

        public void LockGoNextInput()
        {
            _goNextInputIsLocked = true;
        }

        public void UnlockGoNextInput()
        {
            _goNextInputIsLocked = false;
        }
        public void SetStoryLine(IStoryLine storyLine, int startIndex)
        {
            _controller.SetStoryLine(storyLine, startIndex);
        }

        private void OnCommandExecuted(ICommand executedCommand)
        {
            UnityEngine.Debug.Log($"executed cmd: {executedCommand}");
            bool shouldBlock = _blockingCommands.TryGetValue(executedCommand.GetType(), out var isBlocking) && isBlocking;
            _goNextInputIsLocked = shouldBlock;
            UnityEngine.Debug.Log(_goNextInputIsLocked);

            CommandExecuted?.Invoke(executedCommand);
        }

    }
}
