using UnityEngine;

namespace Understanders
{
    internal sealed class CameraUnderstander : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private Color _gizmoColor = Color.cyan;
        [SerializeField] private float _viewPortZ = 1f;


        private void OnDrawGizmos()
        {
            var cam = Camera.main;
            var minPos = cam.ViewportToWorldPoint(new Vector3(0, 0, _viewPortZ));
            var maxPos = cam.ViewportToWorldPoint(new Vector3(1, 1, _viewPortZ));

            Gizmos.color = _gizmoColor;
            Gizmos.DrawSphere(minPos, 1f);
            Gizmos.DrawSphere(maxPos, 1f);
        }

#endif
    }
}
