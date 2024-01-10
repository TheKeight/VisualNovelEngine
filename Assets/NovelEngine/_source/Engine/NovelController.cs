﻿using System;
using System.Collections.Generic;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Engine
{
    internal sealed class NovelController : INovelController
    {
        private readonly ICommandsManager _commandsManager;
        private readonly IReadOnlyDictionary<System.Type, bool> _stoppingCommands;
        private readonly IReadOnlyDictionary<System.Type, bool> _blockingCommands;

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
            _blockingCommands = blockingCommands;
        }


        public bool CanGoNext
        {
            get
            {
                if (_inGoNextLoop)
                    return false;

                if (_storyLine == null)
                    return false;

                if (_storyLine.Commands == null)
                    return false;

                if (_storyLine.Commands.Count <= _nextCommandIndex)
                    return false;

                if (_lastExecutedCommand != null && _blockingCommands[_lastExecutedCommand.GetType()])
                    return false;

                return true;
            }
        }

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
                _commandsManager.Execute(nextCmd);
                _lastExecutedCommand = nextCmd;

                if (ShouldStop())
                    break;
            }

            _inGoNextLoop = false;
        }

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
                return true;

            if (_storyLine.Commands == null)
                return true;

            if (_storyLine.Commands.Count <= _nextCommandIndex)
                return true;

            var type = _lastExecutedCommand.GetType();
            return _stoppingCommands[type] || _blockingCommands[type];
        }
    }
}
