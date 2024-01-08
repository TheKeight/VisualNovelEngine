using System;

namespace VisualNovel.Utility
{
    [Obsolete("usage is not figured out yet...", false)]
    public sealed class FromResultBuilder<TTarget> : IBuilder<TTarget>, ITryingBuilder<TTarget>
    {
        public FromResultBuilder()
        {

        }

        public FromResultBuilder(TTarget result)
        {
            Result = result;
        }


        public TTarget Result { get; set; }


        public TTarget Build() => Result ?? throw new System.NotImplementedException();

        public bool TryBuild(out TTarget target)
        {
            target = Result;
            return Result is not null;
        }
    }
}
