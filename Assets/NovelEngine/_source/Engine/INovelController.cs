using System.Collections.Generic;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Engine
{
    public interface INovelController
    {
        void GoNext();

        void SetStoryLine(IStoryLine storyLine);
        void SetStoryLine(IStoryLine storyLine, int commandIndex);
    }
}
