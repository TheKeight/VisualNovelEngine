using System.Collections.Generic;

namespace VisualNovel.Commands
{
    public interface ISelectorVariant
    {
        string Title { get; }
        IReadOnlyList<CommandSO> Commands { get; }
    }
}
