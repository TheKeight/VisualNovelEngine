using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{

    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(DelayCommand))]
    public sealed class DelayCommand : NovelCommand
    {
        [SerializeField] private float _delaySeconds;


        public float DelaySeconds => _delaySeconds;


        public static DelayCommand Create(float delaySeconds)
        {
            var inst = CreateInstance<DelayCommand>();
            inst._delaySeconds = delaySeconds;
            return inst;
        }
    }
}
