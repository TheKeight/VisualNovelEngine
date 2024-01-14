using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.UX.ItemsOnScene;
using UnityEngine;

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