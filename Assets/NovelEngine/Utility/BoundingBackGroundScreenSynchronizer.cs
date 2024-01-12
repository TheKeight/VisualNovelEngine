using DevourDev.Unity.Utility.Eventers;
using NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Utility
{
    public sealed class BoundingBackGroundScreenSynchronizer : MonoBehaviour
    {
        [SerializeField] private BoundingBackGround _boundingBackGround;


        private void Awake()
        {
            Sync();

            ScreenEventsManager.ResolutionListener.ResolutionChanged += OnResolutionChanged;
        }

        private void OnDestroy()
        {
            ScreenEventsManager.ResolutionListener.ResolutionChanged -= OnResolutionChanged;
        }

        private void OnResolutionChanged(Vector2 previousResolution, Vector2 newResolution)
        {
            Sync();
        }

        private void Sync()
        {
            var cam = Camera.main;
            float camZ = cam.transform.position.z;
            float bgZ = _boundingBackGround.transform.position.z;
            float depth = bgZ - camZ;

            Vector3 vpMin = Vector3.zero;
            Vector3 vpMmax = Vector3.one;
            vpMin.z = vpMmax.z = depth;

            Vector2 min = cam.ViewportToWorldPoint(vpMin);
             Vector2 max = cam.ViewportToWorldPoint(vpMmax);

            _boundingBackGround.Encapsulate(min, max);
        }
    }
}
