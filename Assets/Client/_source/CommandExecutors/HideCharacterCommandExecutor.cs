using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;


namespace VisualNovel.Client.CommandExecutors
{
    public sealed class HideCharacterCommandExecutor : CommandExecutorComponent<HideCharacterCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Execute(HideCharacterCommand command)
        {
            _charactersOnSceneManager.Hide(command.Character);
        }
    }
}