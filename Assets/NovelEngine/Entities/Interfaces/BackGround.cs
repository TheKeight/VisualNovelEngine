using UnityEngine;

namespace NovelEngine.Entities.Interface
{
    public abstract class BackGround : MonoBehaviour, IBackGround
    {
        public abstract void Encapsulate(Vector2 min, Vector2 max);
    }
}
