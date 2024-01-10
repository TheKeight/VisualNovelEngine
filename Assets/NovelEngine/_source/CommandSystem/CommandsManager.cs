using System;
using System.Collections.Generic;

namespace VisualNovel.CommandSystem
{
    public sealed class CommandsManager : ICommandsManager
    {
        private readonly Dictionary<System.Type, ICommandExecutor> _dict = new();

        public void RegisterCommandExecutor(Type commandType, ICommandExecutor commandExecutor)
        {
            _dict.Add(commandType, commandExecutor);
        }

        public void ChangeCommandExecutor(Type commandType, ICommandExecutor newCommandExecutor)
        {
            if (!ContainsCommandExecutor(commandType))
                throw new InvalidOperationException("executor not exist to change it");

            _dict[commandType] = newCommandExecutor;
        }

        public bool ContainsCommandExecutor(Type commandType)
        {
            return _dict.ContainsKey(commandType);
        }

        public void Execute(ICommand command)
        {
            _dict[command.GetType()].Execute(command);
        }
    }
}
