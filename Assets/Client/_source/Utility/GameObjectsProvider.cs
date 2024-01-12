using System;
using DevourDev.Unity.Utility.Serialization;
using UnityEngine;

namespace NovelEngine.Utility
{
    [System.Serializable]
    public sealed class GameObjectsProvider<TKey, TValue> : IGameObjectsProvider<TKey, TValue>
        where TValue : UnityEngine.Object
    {
        [SerializeField] private SerializedDictionaryWithDefaultValue<TKey, TValue> _dict;


        public TValue GetPrefab(TKey key) => _dict[key];

        public TValue GetInstance(TKey key) => GameObject.Instantiate(GetPrefab(key));

        //TODO: implement pool.
        public TValue RentInstance(TKey key)
        {
            return GetInstance(key);
        }

        public void ReturnInstance(TValue value)
        {
            DestroyInstance(value);
        }

        private void DestroyInstance(TValue value)
        {
            UnityEngine.Object objectToDestroy = value switch
            {
                Component cmp => cmp.gameObject,
                GameObject go => go,
                _ => throw new NotImplementedException(),
            };

            UnityEngine.Object.Destroy(objectToDestroy);
        }

    }
}