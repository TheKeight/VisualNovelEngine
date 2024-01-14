using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;

namespace DevourDev.Unity.NovelEngine.Core
{
    public interface INovelController
    {
        bool CanGoNext { get; }

        event System.Action<ICommand> CommandExecuted;

        void GoNext();
        void SetStoryLine(IStoryLine storyLine, int startIndex);
    }
}
