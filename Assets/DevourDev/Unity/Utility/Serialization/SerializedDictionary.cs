using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DevourDev.Unity.Utility.Serialization
{
    [System.Serializable]
    public sealed class SerializedDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        [System.Serializable]
        public struct Bucket
        {
            [SerializeField] private TKey _key;
            [SerializeField] private TValue _value;


            internal readonly void RegisterToDictionary(IDictionary<TKey, TValue> dict)
            {
                dict.Add(_key, _value);
            }
        }


        [SerializeField] private Bucket[] _buckets;

        private IReadOnlyDictionary<TKey, TValue> _dict = null;


        public SerializedDictionary(IEnumerable<Bucket> buckets)
        {
            _buckets = buckets.ToArray();
        }


        public TValue this[TKey key] => Dictionary[key];

        public IEnumerable<TKey> Keys => Dictionary.Keys;

        public IEnumerable<TValue> Values => Dictionary.Values;

        public int Count => Dictionary.Count;


        private IReadOnlyDictionary<TKey, TValue> Dictionary
        {
            get
            {
                _dict ??= CreateDictionary(_buckets);
                return _dict;
            }
        }


        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }
                
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }

        private static IReadOnlyDictionary<TKey, TValue> CreateDictionary(IReadOnlyCollection<Bucket> buckets)
        {
            var dict = new Dictionary<TKey, TValue>(buckets.Count);

            foreach (var b in buckets)
            {
                b.RegisterToDictionary(dict);
            }

            return dict;
        }
    }
}