namespace DevourDev.CommandSystem.Interfaces
{
    public interface ICommandHandler
    {
        void Handle(ICommand command);
    }
}
