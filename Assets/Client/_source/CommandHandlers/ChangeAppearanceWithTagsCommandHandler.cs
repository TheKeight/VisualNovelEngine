using NovelEngine.Commands;
using NovelEngine.UX.ItemsOnScene;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class ChangeAppearanceWithTagsCommandHandler : CommandHandlerComponent<ChangeAppearanceWithTagsCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Handle(ChangeAppearanceWithTagsCommand command)
        {
            _charactersOnSceneManager.ChangeAppearance(command.Character, command.QueryMode, command.Tags, command.BlackListTags);
        }
    }
}