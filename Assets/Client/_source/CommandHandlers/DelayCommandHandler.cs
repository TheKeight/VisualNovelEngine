using System.Collections;
using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Core;
using UnityEngine;

namespace NovelEngine.CommandHandlers.CommandExecutors
{

    public sealed class DelayCommandHandler : CommandHandlerComponent<DelayCommand>
    {
        [SerializeField] private NovelControllerComponent _controller;
        [SerializeField] private bool _ignore = true;

        private Coroutine _delayRoutine = null;


        public override void Handle(DelayCommand command)
        {
            _controller.LockGoNextInput();
        
            if(_delayRoutine != null)
            {
                UnityEngine.Debug.LogError("unexpected: _delayRoutine != null");
                StopCoroutine(_delayRoutine);
            }

            _delayRoutine = StartCoroutine(GetGoNextAfterRoutine(command.DelaySeconds));
        }


        private IEnumerator GetGoNextAfterRoutine(float delayTime)
        {
            yield return _ignore ? null : new WaitForSeconds(delayTime);
            //_controller.UnlockGoNextInput();
            _delayRoutine = null;
            _controller.GoNext();
        }
    }
}