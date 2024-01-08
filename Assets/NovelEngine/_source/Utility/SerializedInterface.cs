using UnityEngine;

namespace VisualNovel.Utility
{
    [System.Serializable]
    public sealed class SerializedInterface<T>
        where T : class
    {
        [SerializeField] private UnityEngine.Object _rawObject;

        private T _item;


        public T Item
        {
            get
            {
                _item ??= InitItem();
                return _item;
            }
        }

        private T InitItem()
        {
            if (_rawObject is GameObject go)
                return go.GetComponent<T>();

            return (T)(object)_rawObject;
        }
    }
}