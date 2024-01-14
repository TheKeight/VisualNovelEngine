using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.UX.ItemsOnScene;
using UnityEngine;

namespace NovelEngine.CommandHandlers.CommandExecutors
{
    public sealed class ShowCharacterWithTagsCommandExecutor : CommandHandlerComponent<ShowCharacterWithTagsCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Handle(ShowCharacterWithTagsCommand command)
        {
            _charactersOnSceneManager.Show(command.Character, command.Position, command.QueryMode, command.Tags, command.BlackListTags);
        }
    }
}