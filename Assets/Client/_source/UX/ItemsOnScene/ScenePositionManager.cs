using UnityEngine;

namespace NovelEngine.CommandHandlers.UX
{
    public sealed class ScenePositionManager : PositionManager
    {
        [SerializeField] private Transform _minPoint;
        [SerializeField] private Transform _maxPoint;
        [SerializeField] private float _zPosition = 0f;

        public override void ChangePosition(Transform tr, float position)
        {
            Vector3 min = _minPoint.position;
            Vector3 max = _maxPoint.position;

            Vector3 pos = new Vector3
            {
                x = Mathf.Lerp(min.x, max.x, position),
                y = Mathf.Lerp(min.y, max.y, position),
                z = _zPosition
            };

            tr.position = pos;
        }
    }
}