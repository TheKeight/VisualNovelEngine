namespace DevourDev.CommandSystem.Interfaces
{
    public interface ICommandHandler<TCmd> : ICommandHandler
        where TCmd : ICommand
    {
        void Handle(TCmd command);

        void ICommandHandler.Handle(ICommand command) => Handle((TCmd)command);
    }
}
