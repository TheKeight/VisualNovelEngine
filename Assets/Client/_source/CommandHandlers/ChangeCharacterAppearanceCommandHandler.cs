using UnityEngine;
using NovelEngine.CommandHandlers.UX;
using NovelEngine.Commands;

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