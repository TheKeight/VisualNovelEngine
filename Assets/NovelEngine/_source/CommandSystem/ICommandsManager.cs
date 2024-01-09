using System;

namespace VisualNovel.CommandSystem
{
    public interface ICommandsManager
    {
        void RegisterCommandExecutor(Type commandType, ICommandExecutor commandExecutor);
        void ChangeCommandExecutor(Type commandType, ICommandExecutor newCommandExecutor);
        bool ContainsCommandExecutor(Type commandType);

        void Execute(ICommand command);
    }
}
