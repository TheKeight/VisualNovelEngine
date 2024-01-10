using VisualNovel.Entities;

namespace VisualNovel.Engine
{
    public interface INovelController
    {
        bool CanGoNext { get; }


        void GoNext();
        void SetStoryLine(IStoryLine storyLine, int startIndex);
    }
}
