using DevourDev.Unity.NovelEngine.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NovelEngine.UX.Dialogue
{
    public sealed class GoNextUserInputManager : MonoBehaviour
    {
        [SerializeField] private NovelControllerComponent _controller;
        [SerializeField] private Button _goNextButton;


        private void Awake()
        {
            _goNextButton.onClick.AddListener(HandleClick);
        }


        private void Update()
        {
            _goNextButton.interactable = _controller.CanGoNext;    
        }


        private void HandleClick()
        {
            if (!_controller.CanGoNext)
                return;

            _controller.GoNext();
        }
    }
}
