using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    public sealed class ScenePositionManager : PositionManager
    {
        [SerializeField] private Transform _minPoint;
        [SerializeField] private Transform _maxPoint;
        [SerializeField] private float _zPosition = 0f;

        public override Vector3 GetWorldPosition(float oneDPosition)
        {
            Vector3 min = _minPoint.position;
            Vector3 max = _maxPoint.position;

            Vector3 pos = new Vector3
            {
                x = Mathf.Lerp(min.x, max.x, oneDPosition),
                y = Mathf.Lerp(min.y, max.y, oneDPosition),
                z = _zPosition
            };

            return pos;
        }
    }
}