using System.Collections.Generic;
using System.Linq;

namespace VisualNovel.Utility
{
    public static class BuildersUtility
    {
        private readonly struct DefaultToTryingBuilder<TTarget> : ITryingBuilder<TTarget>
        {
            private readonly IBuilder<TTarget> _builder;


            public DefaultToTryingBuilder(IBuilder<TTarget> builder)
            {
                _builder = builder;
            }

            // TODO: Change catch filter to convenient exception types.
            public bool TryBuild(out TTarget target)
            {
                try
                {
                    target = _builder.Build();
                    return true;
                }
                catch (System.Exception)
                {
                    target = default;
                    return false;
                }
            }
        }

        private readonly struct TryingToDefaultBuilder<TTarget> : IBuilder<TTarget>
        {
            private readonly ITryingBuilder<TTarget> _builder;


            public TryingToDefaultBuilder(ITryingBuilder<TTarget> builder)
            {
                _builder = builder;
            }


            public TTarget Build()
            {
                if (_builder.TryBuild(out var target))
                    return target;

                throw new System.NotImplementedException();
            }
        }

        private readonly struct TryingBuildersComposite<TTarget> : ITryingBuilder<TTarget>
        {
            private readonly ITryingBuilder<TTarget>[] _builders;


            public TryingBuildersComposite(IEnumerable<ITryingBuilder<TTarget>> tryingBuilders)
            {
                _builders = tryingBuilders.ToArray();
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
        }


        public static IBuilder<TTarget> ConvertTryingBuilderToDefaultBuilder<TTarget>(ITryingBuilder<TTarget> tryingBuilder)
        {
            return new TryingToDefaultBuilder<TTarget>(tryingBuilder);
        }

        public static ITryingBuilder<TTarget> ConvertDefaultBuilderToTryingBuilder<TTarget>(IBuilder<TTarget> defaultBuilder)
        {
            return new DefaultToTryingBuilder<TTarget>(defaultBuilder);
        }

        public static ITryingBuilder<TTarget> CombineTryingBuilders<TTarget>(params ITryingBuilder<TTarget>[] builders)
        {
            return new TryingBuildersComposite<TTarget>(builders);
        }
    }
}
