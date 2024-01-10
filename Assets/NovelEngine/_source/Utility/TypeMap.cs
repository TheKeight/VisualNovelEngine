using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisualNovel.Utility
{
    [System.Serializable]
    public sealed class TypeMap<TInput, TOutput> : IReadOnlyDictionary<System.Type, TOutput>
    {
        [System.Serializable]
        private struct Slot
        {
            [SerializeField] private TInput _key;
            [SerializeField] private TOutput _value;


            public readonly void RegisterToDictionary(IDictionary<System.Type, TOutput> dictionary)
            {
                dictionary.Add(_key.GetType(), _value);
            }
        }


        [SerializeField] private bool _useDefault = true;
        [SerializeField] private TOutput _defaultValue;
        [SerializeField] private Slot[] _slots;

        private IReadOnlyDictionary<System.Type, TOutput> _dict = null;


        private IReadOnlyDictionary<System.Type, TOutput> Dictionary
        {
            get
            {
                _dict ??= InitDictionary();
                return _dict;
            }
        }

        public TOutput this[Type key]
        {
            get
            {
                if (!_useDefault)
                    return Dictionary[key];

                _ = TryGetValue(key, out var value);
                return value;
            }
        }

        public IEnumerable<Type> Keys => Dictionary.Keys;

        public IEnumerable<TOutput> Values => Dictionary.Values;

        public int Count => Dictionary.Count;


        public bool ContainsKey(Type key)
        {
            if (_useDefault)
                return true;

            return Dictionary.ContainsKey(key);
        }

        public bool TryGetValue(Type key, out TOutput value)
        {
            if (Dictionary.TryGetValue(key, out value))
                return true;

            if (!_useDefault)
                return false;

            value = _defaultValue;
            return true;
        }

        public IEnumerator<KeyValuePair<Type, TOutput>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }

        private IReadOnlyDictionary<Type, TOutput> InitDictionary()
        {
            Dictionary<Type, TOutput> dict = new(_slots.Length);

            foreach (var slot in _slots)
            {
                slot.RegisterToDictionary(dict);
            }

            return dict;
        }
    }
}