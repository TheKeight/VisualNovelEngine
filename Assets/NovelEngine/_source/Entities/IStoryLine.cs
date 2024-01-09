using System.Collections.Generic;
using VisualNovel.Commands;

namespace VisualNovel.Entities
{
    public interface IStoryLine
    {
        IReadOnlyList<CommandSO> Commands { get; }
    }
}