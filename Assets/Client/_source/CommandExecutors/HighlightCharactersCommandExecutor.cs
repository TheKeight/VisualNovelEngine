using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;


namespace VisualNovel.Client.CommandExecutors
{
    public sealed class HighlightCharactersCommandExecutor : CommandExecutorComponent<HighlightCharactersCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Execute(HighlightCharactersCommand command)
        {
            _charactersOnSceneManager.Highlight(command.Characters);
        }
    }
}