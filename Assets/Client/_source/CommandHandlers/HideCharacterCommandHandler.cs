using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.UX.ItemsOnScene;
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