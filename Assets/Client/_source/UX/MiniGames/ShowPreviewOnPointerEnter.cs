using UnityEngine;
using UnityEngine.EventSystems;

namespace NovelEngine.UX.MiniGames
{
    public sealed class ShowPreviewOnPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _previewObject;
        [SerializeField] private float _timeToTrigger = 0.5f;

        private bool _isShowingPreview;
        private bool _isCountingDown;
        private float _timeToTriggerLeft;


        private void Start()
        {
            _previewObject.SetActive(false);
        }

        private void Update()
        {
            CountDown(Time.deltaTime);
        }

        private void CountDown(float deltaTime)
        {
            if (!_isCountingDown || _isShowingPreview)
                return;

            if ((_timeToTriggerLeft -= deltaTime) > 0)
                return;

            Trigger();
        }

        private void Trigger()
        {
            _isShowingPreview = true;
            _previewObject.SetActive(true);
        }

        private void Clear()
        {
            if (!_isShowingPreview)
                return;

            _isShowingPreview = false;
            _previewObject.SetActive(false);
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            _isCountingDown = true;
            _timeToTriggerLeft = _timeToTrigger;
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            _isCountingDown = false;
            Clear();
        }
    }
}
