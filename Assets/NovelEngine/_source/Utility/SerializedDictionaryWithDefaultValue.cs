using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Assertions;

namespace VisualNovel.Utility
{
    [System.Serializable]
    public sealed class SerializedDictionaryWithDefaultValue<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        [SerializeField, Required] private TValue _defaultValue;
        [SerializeField] private SerializedDictionary<TKey, TValue> _serializedDictionary;


#if UNITY_EDITOR
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AssertState()
        {
            if (!typeof(TValue).IsClass)
                return;

            Assert.IsNotNull<object>(_defaultValue, $"{nameof(SerializedDictionaryWithDefaultValue<TKey, TValue>)} should have Default Value");
        }
#endif

        public TValue GetDefaultValue() => _defaultValue;

        public TValue GetValueOrDefault(TKey key)
        {
            if (key is null || !_serializedDictionary.TryGetValue(key, out var value))
                value = GetDefaultValue();

            return value;
        }

        public bool ContainsKey(TKey key)
        {
            return _serializedDictionary.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _serializedDictionary.TryGetValue(key, out value);
        }

        public TValue this[TKey key] => ((IReadOnlyDictionary<TKey, TValue>)_serializedDictionary)[key];

        public IEnumerable<TKey> Keys => _serializedDictionary.Keys;

        public IEnumerable<TValue> Values => _serializedDictionary.Values;

        public int Count => _serializedDictionary.Count;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _serializedDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_serializedDictionary).GetEnumerator();
        }
    }
}