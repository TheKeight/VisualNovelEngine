using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevourDev.Unity.Utility.Attributes;
using UnityEngine;
using UnityEngine.Assertions;

namespace DevourDev.Unity.Utility.Serialization
{
    [System.Serializable]
    public sealed class SerializedDictionaryWithDefaultValue<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        [SerializeField, Required] private TValue _defaultValue;
        [SerializeField] private SerializedDictionary<TKey, TValue> _serializedDictionary;


        public SerializedDictionaryWithDefaultValue(TValue defaultValue,
            SerializedDictionary<TKey, TValue> serializedDictionary)
        {
            _defaultValue = defaultValue;
            _serializedDictionary = serializedDictionary;
        }


        public TValue this[TKey key] => GetValueOrDefault(key);

        public IEnumerable<TKey> Keys => _serializedDictionary.Keys;

        public IEnumerable<TValue> Values => _serializedDictionary.Values;

        public int Count => _serializedDictionary.Count;


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
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = GetValueOrDefault(key);
            return true;
        }

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