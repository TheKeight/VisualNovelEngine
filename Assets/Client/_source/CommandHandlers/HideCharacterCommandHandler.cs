using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.CommandHandlers.UX;
using UnityEngine;


namespace NovelEngine.CommandHandlers
{
    public sealed class HideCharacterCommandHandler : CommandHandlerComponent<HideCharacterCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Handle(HideCharacterCommand command)
        {
            _charactersOnSceneManager.Hide(command.Character);
        }
    }
}