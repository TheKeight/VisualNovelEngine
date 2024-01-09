﻿using System.Collections.Generic;
using VisualNovel.Commands;
using VisualNovel.Entities;

namespace VisualNovel.Engine
{
    public interface INovelController
    {
        NovelPlayMode Mode { get; set; }

        void GoNext();

        void SetStoryLine(StoryLineSO storyLine);
        void SetStoryLine(StoryLineSO storyLine, int commandIndex);
        void InsertCommands(IEnumerable<CommandSO> commands);
    }


}