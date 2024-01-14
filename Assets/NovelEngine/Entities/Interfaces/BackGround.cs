using UnityEngine;

namespace NovelEngine.Entities.Interface
{
    public abstract class BackGround : MonoBehaviour, IBackGround
    {
        [System.Obsolete("todo: rename", false)]
        public abstract void Encapsulate(Vector2 min, Vector2 max);
    }
}
