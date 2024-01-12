using UnityEngine;

namespace NovelEngine.Entities
{
    public sealed class BoundingBackGroundTester : MonoBehaviour
    {
        [SerializeField] private BoundingBackGround _boundingBackGround;
        [SerializeField] private Transform _targetMin;
        [SerializeField] private Transform _targetMax;
        [SerializeField] private bool _encapsulate;


        private void Update()
        {
            if (!_encapsulate)
                return;

            //_encapsulate = false;
            _boundingBackGround.Encapsulate(_targetMin.position, _targetMax.position);
        }
    }
}
