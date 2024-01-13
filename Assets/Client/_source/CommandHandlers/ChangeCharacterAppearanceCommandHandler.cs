using NovelEngine.Commands;
using NovelEngine.UX.ItemsOnScene;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class ChangeCharacterAppearanceCommandHandler : CommandHandlerComponent<ChangeCharacterAppearanceCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Handle(ChangeCharacterAppearanceCommand command)
        {
            _charactersOnSceneManager.ChangeAppearance(command.Character, command.AppearanceKey);
        }
    }
}