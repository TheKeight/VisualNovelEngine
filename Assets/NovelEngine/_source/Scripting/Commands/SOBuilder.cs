using UnityEngine;

namespace VisualNovel.Scripting.Commands
{
    public abstract class SOBuilder : IBuilder<ScriptableObject>
    {
        public abstract ScriptableObject Build();
    }

    public abstract class SOBuilder<T> : SOBuilder
    where T : ScriptableObject
    {
        private T _result;


        public void SetResult(T result) => _result = result;

        public sealed override ScriptableObject Build() => BuildConcrete();

        public T BuildConcrete()
        {
            if (_result is null)
                _result = BuildConcreteInternal();

            return _result;
        }

        protected abstract T BuildConcreteInternal();
    }
}
