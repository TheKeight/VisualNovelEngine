namespace VisualNovel.Utility
{
    public interface ITryingBuilder<TTarget>
    {
        bool TryBuild(out TTarget target);
    }
}
