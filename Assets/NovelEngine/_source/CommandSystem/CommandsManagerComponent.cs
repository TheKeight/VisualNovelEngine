using System;
using UnityEngine;

namespace VisualNovel.CommandSystem
{
    [DefaultExecutionOrder(-3000)]
    public sealed class CommandsManagerComponent : MonoBehaviour, ICommandsManager
    {
        private readonly CommandsManager _commandsManager = new();


        public void RegisterCommandExecutor(Type commandType, ICommandExecutor commandExecutor)
        {
            _commandsManager.RegisterCommandExecutor(commandType, commandExecutor);
        }

        public void ChangeCommandExecutor(Type commandType, ICommandExecutor newCommandExecutor)
        {
            _commandsManager.ChangeCommandExecutor(commandType, newCommandExecutor);
        }

        public bool ContainsCommandExecutor(Type commandType)
        {
            return _commandsManager.ContainsCommandExecutor(commandType);
        }

        public void Execute(ICommand command)
        {
            _commandsManager.Execute(command);
        }
    }
}
