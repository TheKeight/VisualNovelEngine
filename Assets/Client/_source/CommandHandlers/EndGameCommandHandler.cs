using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.UX.GameEnding;
using UnityEngine;

namespace NovelEngine.CommandHandlers.CommandExecutors
{
    public sealed class EndGameCommandHandler : CommandHandlerComponent<EndGameCommand>
    {
        [SerializeField] private EndGameManager _endGameManager;


        public override void Handle(EndGameCommand command)
        {
            _endGameManager.EndGame(command.EndGameMessage);
        }
    }
}