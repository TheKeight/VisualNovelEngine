namespace VisualNovel.Utility
{
    public interface IBuilder<out TTarget>
    {
        TTarget Build();
    }
}
