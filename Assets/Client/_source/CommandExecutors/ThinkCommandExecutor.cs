using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX.Dialogue;

namespace VisualNovel.Client.CommandExecutors
{

    public sealed class ThinkCommandExecutor : CommandExecutorComponent<ThinkCommand>
    {
        [SerializeField] private DialogueManager _dialogueManager;


        public override void Execute(ThinkCommand command)
        {
            _dialogueManager.Think(command.Character, command.Text);
        }
    }
}