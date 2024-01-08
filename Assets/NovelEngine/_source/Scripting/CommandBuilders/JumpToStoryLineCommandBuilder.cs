using VisualNovel.Commands;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Scripting.CommandBuilders
{

    public sealed class JumpToStoryLineCommandBuilder : IBuilder<JumpToStoryLineCommand>
    {
        private readonly IBuilder<StoryLineSO> _storyLineBuilder;


        public JumpToStoryLineCommandBuilder(IBuilder<StoryLineSO> storyLineBuilder)
        {
            _storyLineBuilder = storyLineBuilder;
        }


        public JumpToStoryLineCommand Build()
        {
            return JumpToStoryLineCommand.Create(_storyLineBuilder.Build());
        }
    }
}
