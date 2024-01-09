using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ShowCharacterCommandExecutor : CommandExecutorComponent<ShowCharacterCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Execute(ShowCharacterCommand command)
        {
            _charactersOnSceneManager.Show(command.Character, command.AppearanceKey, command.Position);
        }
    }
}