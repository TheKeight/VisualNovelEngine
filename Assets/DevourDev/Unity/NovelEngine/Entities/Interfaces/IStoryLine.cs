using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;

namespace DevourDev.Unity.NovelEngine.Entities.Interfaces
{
    public interface IStoryLine
    {
        IReadOnlyList<NovelCommand> Commands { get; }
    }
}