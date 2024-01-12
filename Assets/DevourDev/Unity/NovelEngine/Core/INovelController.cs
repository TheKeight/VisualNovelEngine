using DevourDev.Unity.NovelEngine.Entities.Interfaces;

namespace DevourDev.Unity.NovelEngine.Core
{
    public interface INovelController
    {
        bool CanGoNext { get; }


        void GoNext();
        void SetStoryLine(IStoryLine storyLine, int startIndex);
    }
}
