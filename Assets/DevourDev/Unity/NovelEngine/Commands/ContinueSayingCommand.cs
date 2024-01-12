using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{

    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ContinueSayingCommand))]
    public sealed class ContinueSayingCommand : NovelCommand
    {
        [SerializeField] private string _speech;


        public string Speech => _speech;


        public static ContinueSayingCommand Create(string speech)
        {
            var inst = CreateInstance<ContinueSayingCommand>();
            inst._speech = speech;
            return inst;
        }
    }


}
