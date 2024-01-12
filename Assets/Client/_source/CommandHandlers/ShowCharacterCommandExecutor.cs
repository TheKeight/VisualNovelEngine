using NovelEngine.Commands;
using UnityEngine;
using NovelEngine.CommandHandlers.UX;
using DevourDev.Unity.NovelEngine.Commands;

namespace NovelEngine.CommandHandlers.CommandExecutors
{
    public sealed class ShowCharacterCommandExecutor : CommandHandlerComponent<ShowCharacterCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Handle(ShowCharacterCommand command)
        {
            _charactersOnSceneManager.Show(command.Character, command.AppearanceKey, command.Position);
        }
    }
}