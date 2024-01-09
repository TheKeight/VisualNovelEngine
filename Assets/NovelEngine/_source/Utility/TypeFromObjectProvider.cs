using UnityEngine;

namespace VisualNovel.Utility
{
    [System.Serializable]
    public sealed class TypeFromObjectProvider<T> : IItemProvider<System.Type>
    {
        [SerializeField] private T _object;


        public System.Type Item => _object.GetType();
    }
}