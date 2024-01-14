using NovelEngine.Commands.MiniGames;
using NovelEngine.UX.MiniGames;
using UnityEngine;

namespace NovelEngine.CommandHandlers.MiniGames
{
    public sealed class StartNsfwMiniGameCommandHandler : CommandHandlerComponent<StartNsfwMiniGameCommand>
    {
        [SerializeField] private NsfwMiniGame _miniGamePrefab;
        [SerializeField] private JumpToStoryLineCommandHandler _jumper;


        public override void Handle(StartNsfwMiniGameCommand command)
        {
            var game = Instantiate(_miniGamePrefab);
            game.Init(() => _jumper.Jump(command.BDestination));
        }
    }
}
