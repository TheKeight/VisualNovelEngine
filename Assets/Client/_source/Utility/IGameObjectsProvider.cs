using UnityEngine;

namespace VisualNovel.Client.Utility
{
    public interface IGameObjectsProvider<TKey, TValue> where TValue : Object
    {
        TValue GetInstance(TKey key);
        TValue GetPrefab(TKey key);
        TValue RentInstance(TKey key);
        void ReturnInstance(TValue value);
    }
}