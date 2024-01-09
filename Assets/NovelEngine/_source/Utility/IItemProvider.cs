namespace VisualNovel.Utility
{
    public interface IItemProvider<T>
    {
        T Item { get; }
    }
}