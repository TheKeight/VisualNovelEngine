namespace VisualNovel.CommandSystem
{
    public interface ICommandExecutor<TCmd> : ICommandExecutor
        where TCmd : ICommand
    {
        void Execute(TCmd command);

        void ICommandExecutor.Execute(ICommand command) => Execute(command);
    }
}
