using DevourDev.Unity.NovelEngine.Core;
using NovelEngine.Commands.MiniGames;
using NovelEngine.UX.MiniGames;
using UnityEngine;

namespace NovelEngine.CommandHandlers.MiniGames
{
    public sealed class StartNsfwMiniGameCommandHandler : CommandHandlerComponent<StartNsfwMiniGameCommand>
    {
        [SerializeField] private NsfwMiniGame _miniGamePrefab;
        [SerializeField] private NovelControllerComponent _controller;


        public override void Handle(StartNsfwMiniGameCommand command)
        {
            var game = Instantiate(_miniGamePrefab);
            game.Init(() =>
            {
                _controller.SetStoryLine(command.BDestination, 0);
                _controller.GoNext();
            });
        }
    }
}
