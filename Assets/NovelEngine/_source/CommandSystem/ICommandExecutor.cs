namespace VisualNovel.CommandSystem
{
    public interface ICommandExecutor
    {
        void Execute(ICommand command);
    }
}
