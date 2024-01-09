using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    public abstract class PositionManager : MonoBehaviour
    {
        public abstract void ChangePosition(Transform tr, ScenePositionSO position);
    }
}