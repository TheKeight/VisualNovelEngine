//#define LOG_REASONS
using System;
using System.Collections.Generic;
using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;

namespace DevourDev.Unity.NovelEngine.Core
{
    internal sealed class NovelController : INovelController
    {
        private readonly ICommandsManager _commandsManager;
        private readonly IReadOnlyDictionary<System.Type, bool> _stoppingCommands;
        //private readonly IReadOnlyDictionary<System.Type, bool> _blockingCommands;

        private IStoryLine _storyLine;
        private ICommand _lastExecutedCommand;
        private int _nextCommandIndex;
        private bool _inGoNextLoop;


        public NovelController(ICommandsManager commandsManager,
            IReadOnlyDictionary<Type, bool> stoppingCommands,
            IReadOnlyDictionary<Type, bool> blockingCommands)
        {
            _commandsManager = commandsManager;
            _stoppingCommands = stoppingCommands;
            //_blockingCommands = blockingCommands;
        }


        public bool CanGoNext
        {
            get
            {
                if (_inGoNextLoop)
                {
#if UNITY_EDITOR && LOG_REASONS
                    UnityEngine.Debug.Log("Can NOT GoNext because of _inGoNextLoop");
#endif
                    return false;
                }

                if (_storyLine == null)
                {
#if UNITY_EDITOR && LOG_REASONS
                    UnityEngine.Debug.Log("Can NOT GoNext because of _storyLine == null");
#endif
                    return false;
                }

                if (_storyLine.Commands == null)
                {
#if UNITY_EDITOR && LOG_REASONS
                    UnityEngine.Debug.Log("Can NOT GoNext because of _storyLine.Commands == null");
#endif
                    return false;
                }

                if (_storyLine.Commands.Count <= _nextCommandIndex)
                {
#if UNITY_EDITOR && LOG_REASONS
                    UnityEngine.Debug.Log("Can NOT GoNext because of _storyLine.Commands.Count <= _nextCommandIndex");
#endif
                    return false;
                }

//                if (_lastExecutedCommand != null && _blockingCommands[_lastExecutedCommand.GetType()])
//                {
//#if UNITY_EDITOR
//                    UnityEngine.Debug.Log("Can NOT GoNext because of _blockingCommands[_lastExecutedCommand.GetType()]");
//#endif
//                    return false;
//                }

                return true;
            }
        }


        public event System.Action<ICommand> CommandExecuted;


        public void GoNext()
        {
            if (_inGoNextLoop)
            {
                throw new InvalidOperationException("go next recursive call");
            }

            if (!CanGoNext)
            {
                throw new InvalidOperationException("can go next violation");
            }

            _inGoNextLoop = true;

            while (true)
            {
                var nextCmd = _storyLine.Commands[_nextCommandIndex];
                ++_nextCommandIndex;
                _commandsManager.Handle(nextCmd);
                _lastExecutedCommand = nextCmd;
                CommandExecuted?.Invoke(nextCmd);

                if (ShouldStop())
                    break;
            }

            _inGoNextLoop = false;
        }

        public void SetStoryLine(IStoryLine storyLine) => SetStoryLine(storyLine, 0);

        public void SetStoryLine(IStoryLine storyLine, int startIndex)
        {
            _storyLine = storyLine;
            _nextCommandIndex = startIndex;

            //

            _lastExecutedCommand = null;
        }

        private bool ShouldStop()
        {
            if (_storyLine == null)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.Log("Should stop because of _storyLine == null");
#endif
                return true;
            }

            if (_storyLine.Commands == null)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.Log("Should stop because of _storyLine.Commands == null");
#endif
                return true;
            }

            if (_storyLine.Commands.Count <= _nextCommandIndex)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.Log("Should stop because of _storyLine.Commands.Count <= _nextCommandIndex");
#endif
                return true;
            }

            var type = _lastExecutedCommand.GetType();

            if (_stoppingCommands[type])
            {
#if UNITY_EDITOR
                UnityEngine.Debug.Log("Should stop because of _stoppingCommands[type]");
#endif
                return true;
            }

//            if (_blockingCommands[type])
//            {
//#if UNITY_EDITOR
//                UnityEngine.Debug.Log("Should stop because of _blockingCommands[type]");
//#endif
//                return true;
//            }

            return false;
        }
    }
}
