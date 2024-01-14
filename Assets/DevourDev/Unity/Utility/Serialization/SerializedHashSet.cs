using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevourDev.Unity.Utility.Serialization
{
    [System.Serializable]
    public sealed class SerializedHashSet<T> : IReadOnlyCollection<T>, IReadOnlyList<T>
    {
        [SerializeField] private T[] _items;

        private HashSet<T> _hs = null;

        
        private HashSet<T> HS
        {
            get
            {
                _hs ??= InitHS(_items);
                return _hs;
            }
        }

        private HashSet<T> InitHS(T[] items)
        {
            var hs = new HashSet<T>(items);
            return hs;
        }

        public int Count => ((IReadOnlyCollection<T>)HS).Count;
        public T this[int index] => ((IReadOnlyList<T>)_items)[index];


        public bool Contains(T value) => HS.Contains(value);

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

    }
}