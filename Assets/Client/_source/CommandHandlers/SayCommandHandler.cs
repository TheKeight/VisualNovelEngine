using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.UX.Dialogue;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class SayCommandHandler : CommandHandlerComponent<SayCommand>
    {
        [SerializeField] private DialogueManager _dialogueManager;


        public override void Handle(SayCommand command)
        {
            _dialogueManager.Say(command.Character, command.Speech);
        }
    }
}