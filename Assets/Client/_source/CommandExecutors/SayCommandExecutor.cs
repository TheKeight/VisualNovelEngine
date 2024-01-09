using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX.Dialogue;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class SayCommandExecutor : CommandExecutorComponent<SayCommand>
    {
        [SerializeField] private DialogueManager _dialogueManager;


        public override void Execute(SayCommand command)
        {
            _dialogueManager.Say(command.Character, command.Text);
        }
    }
}