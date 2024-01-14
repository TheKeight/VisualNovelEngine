using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    public abstract class PositionManager : MonoBehaviour
    {
        public abstract Vector3 GetWorldPosition(float oneDPosition);
    }
}