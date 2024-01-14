using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(EndGameCommand))]
    public sealed class EndGameCommand : NovelCommand
    {
        [SerializeField] private string _endGameMessage;


        public string EndGameMessage => _endGameMessage;


        public static EndGameCommand Create(string endGameMessage)
        {
            var inst = CreateInstance<EndGameCommand>();
            inst._endGameMessage = endGameMessage;
            return inst;
        }
    }
}
