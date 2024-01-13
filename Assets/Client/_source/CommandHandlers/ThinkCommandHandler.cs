using NovelEngine.Commands;
using NovelEngine.UX.Dialogue;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class ThinkCommandHandler : CommandHandlerComponent<ThinkCommand>
    {
        [SerializeField] private DialogueManager _dialogueManager;


        public override void Handle(ThinkCommand command)
        {
            _dialogueManager.Think(command.Character, command.Thought);
        }
    }
}