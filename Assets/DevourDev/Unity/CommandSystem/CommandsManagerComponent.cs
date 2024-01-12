using System;
using DevourDev.CommandSystem;
using DevourDev.CommandSystem.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.CommandSystem
{
    public sealed class CommandsManagerComponent : MonoBehaviour, ICommandsManager
    {
        private readonly CommandsManager _commandsManager = new();


        public void RegisterHandler(Type commandType, ICommandHandler commandExecutor)
        {
            _commandsManager.RegisterHandler(commandType, commandExecutor);
        }

        public void ChangeHandler(Type commandType, ICommandHandler newCommandExecutor)
        {
            _commandsManager.ChangeHandler(commandType, newCommandExecutor);
        }

        public bool ContainsHandler(Type commandType)
        {
            return _commandsManager.ContainsHandler(commandType);
        }

        public void Handle(ICommand command)
        {
            _commandsManager.Handle(command);
        }
    }
}
