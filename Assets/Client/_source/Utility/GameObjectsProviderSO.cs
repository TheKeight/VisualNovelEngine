using UnityEngine;

namespace NovelEngine.Utility
{
    public abstract class GameObjectsProviderSO<TKey, TValue> : ScriptableObject, IGameObjectsProvider<TKey, TValue>
     where TValue : UnityEngine.Object
    {
        [SerializeField] private GameObjectsProvider<TKey, TValue> _provider;

        public TValue GetInstance(TKey key)
        {
            return _provider.GetInstance(key);
        }

        public TValue GetPrefab(TKey key)
        {
            return _provider.GetPrefab(key);
        }

        public TValue RentInstance(TKey key)
        {
            return _provider.RentInstance(key);
        }

        public void ReturnInstance(TValue value)
        {
            _provider.ReturnInstance(value);
        }
    }
}