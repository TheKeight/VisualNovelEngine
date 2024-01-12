using UnityEngine;

namespace NovelEngine.Utility
{
    public interface IGameObjectsProvider<TKey, TValue> where TValue : Object
    {
        TValue GetInstance(TKey key);
        TValue GetPrefab(TKey key);
        TValue RentInstance(TKey key);
        void ReturnInstance(TValue value);
    }
}