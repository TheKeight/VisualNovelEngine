using System.Collections.Generic;
using System.Linq;
using VisualNovel.Commands;
using VisualNovel.Utility;

namespace VisualNovel.Scripting.CommandBuilders
{
    public sealed class ShowSelectorCommandBuilder : IBuilder<ShowSelectorCommand>
    {
        public string Title { get; set; }
        public List<SelectorVariantBuilder> Variants { get; set; }


        public ShowSelectorCommand Build()
        {
            IEnumerable<ShowSelectorCommand.Variant> variants = Variants.Select(v => v.Build());
            return ShowSelectorCommand.Create(Title, variants);
        }
    }
}
