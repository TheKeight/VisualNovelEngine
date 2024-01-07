using VisualNovel.Commands;

namespace VisualNovel.Scripting.Commands
{
    public abstract class CommandBuilder : SOBuilder<CommandSO>
    {
    }

    public abstract class CommandBuilder<TCmd> : CommandBuilder
    where TCmd : CommandSO
    {
    }
}
