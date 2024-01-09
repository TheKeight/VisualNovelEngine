using UnityEngine;
using VisualNovel.Client.UX;
using VisualNovel.Commands;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ChangeCharacterAppearanceCommandExecutor : CommandExecutorComponent<ChangeCharacterAppearanceCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Execute(ChangeCharacterAppearanceCommand command)
        {
            _charactersOnSceneManager.ChangeAppearance(command.Character, command.AppearanceKey);
        }
    }
}