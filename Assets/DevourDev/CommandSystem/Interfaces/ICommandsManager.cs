using System;

namespace DevourDev.CommandSystem.Interfaces
{
    public interface ICommandsManager : ICommandHandler
    {
        void RegisterHandler(Type commandType, ICommandHandler handler);
        void ChangeHandler(Type commandType, ICommandHandler newHandler);
        bool ContainsHandler(Type commandType);
    }
}
