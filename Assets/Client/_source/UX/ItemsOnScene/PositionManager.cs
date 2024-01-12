using UnityEngine;
using NovelEngine.Entities;

namespace NovelEngine.CommandHandlers.UX
{
    public abstract class PositionManager : MonoBehaviour
    {
        public abstract void ChangePosition(Transform tr, float position);
    }
}