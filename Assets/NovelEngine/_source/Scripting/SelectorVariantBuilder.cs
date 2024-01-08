using VisualNovel.Commands;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Scripting
{
    public sealed class SelectorVariantBuilder : IBuilder<ShowSelectorCommand.Variant>
    {
        public string Title { get; set; }
        public IBuilder<StoryLineSO> StoryLineBuilder { get; set; }


        public ShowSelectorCommand.Variant Build()
        {
            var jumpCmd = JumpToStoryLineCommand.Create(StoryLineBuilder.Build());
            return ShowSelectorCommand.Variant.Create(Title, new CommandSO[] { jumpCmd });
        }
    }
}
