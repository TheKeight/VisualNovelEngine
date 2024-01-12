using System;
using System.Collections.Generic;
using DevourDev.CommandSystem.Interfaces;

namespace DevourDev.CommandSystem
{
    public sealed class CommandsManager : ICommandsManager
    {
        private readonly Dictionary<System.Type, ICommandHandler> _dict = new();


        public void RegisterHandler(Type commandType, ICommandHandler commandExecutor)
        {
            _dict.Add(commandType, commandExecutor);
        }

        public void ChangeHandler(Type commandType, ICommandHandler newCommandExecutor)
        {
            if (!ContainsHandler(commandType))
                throw new InvalidOperationException("executor not exist to change it");

            _dict[commandType] = newCommandExecutor;
        }

        public bool ContainsHandler(Type commandType)
        {
            return _dict.ContainsKey(commandType);
        }

        public void Handle(ICommand command)
        {
            _dict[command.GetType()].Handle(command);
        }
    }
}
