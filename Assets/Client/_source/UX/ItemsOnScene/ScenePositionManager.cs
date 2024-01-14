using DevourDev.Unity.Utility.Eventers;
using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    public sealed class ScenePositionManager : PositionManager
    {
        [SerializeField] private Transform _minPoint;
        [SerializeField] private Transform _maxPoint;
        [SerializeField] private float _zPosition = 0f;

        private float _yPosition;


        private void Awake()
        {
            ScreenEventsManager.ResolutionListener.ResolutionChanged += ResolutionListener_ResolutionChanged;
            ResolutionListener_ResolutionChanged(ScreenEventsManager.ResolutionListener.Resolution, ScreenEventsManager.ResolutionListener.Resolution);
        }

        private void ResolutionListener_ResolutionChanged(Vector2 previousResolution, Vector2 newResolution)
        {
            Vector3 viewPortPosition = new Vector3(0, 0, _zPosition);
            _yPosition = Camera.main.ViewportToWorldPoint(viewPortPosition).y;
        }

        public override Vector3 GetWorldPosition(float oneDPosition)
        {
            Vector3 min = _minPoint.position;
            Vector3 max = _maxPoint.position;

            Vector3 pos = new Vector3
            {
                x = Mathf.Lerp(min.x, max.x, oneDPosition),
                y = _yPosition,
                z = _zPosition
            };

            return pos;
        }
    }
}