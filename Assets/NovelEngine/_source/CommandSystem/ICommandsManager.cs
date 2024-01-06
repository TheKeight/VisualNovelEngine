using System;

namespace VisualNovel.CommandSystem
{
    public interface ICommandsManager
    {
        void RegisterCommandExecutor(ICommandExecutor commandExecutor);
        void ChangeCommandExecutor(ICommandExecutor newCommandExecutor);
        bool ContainsCommandExecutor(Type commandType);

        void Execute(ICommand command);
    }
}
