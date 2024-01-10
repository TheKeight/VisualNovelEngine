using System;

namespace DevourDev.CommandSystem.Interfaces
{
    public interface ICommandsManager
    {
        void RegisterCommandExecutor(Type commandType, ICommandExecutor commandExecutor);
        void ChangeCommandExecutor(Type commandType, ICommandExecutor newCommandExecutor);
        bool ContainsCommandExecutor(Type commandType);

        void Execute(ICommand command);
    }
}
