using UnityEngine;
using NovelEngine.Entities;

namespace NovelEngine.UX.ItemsOnScene
{
    public abstract class PositionManager : MonoBehaviour
    {
        public abstract void ChangePosition(Transform tr, float position);
    }
}