using System.Collections.Generic;
using System.Linq;

namespace VisualNovel.Utility
{
    public sealed class BuildersComposite<TTarget> : IBuilder<TTarget>, ITryingBuilder<TTarget>
    {
        private readonly ITryingBuilder<TTarget>[] _builders;


        public BuildersComposite(IEnumerable<ITryingBuilder<TTarget>> builders)
        {
            _builders = builders.ToArray();
        }

        public bool TryBuild(out TTarget target)
        {
            foreach (var builder in _builders)
            {
                if (builder.TryBuild(out target))
                    return true;
            }

            target = default;
            return false;
        }

        public TTarget Build()
        {
            if (TryBuild(out var target))
                return target;

            throw new System.NotImplementedException();
        }
    }
}
