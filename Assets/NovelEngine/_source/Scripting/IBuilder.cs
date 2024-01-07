namespace VisualNovel.Scripting
{
    public interface IBuilder<TTarget>
    {
        TTarget Build();
    }
}
