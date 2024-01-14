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
            if (!string.IsNullOrEmpty(command.NameOverride))
            {
                _dialogueManager.Think(command.NameOverride, command.Thought);
            }
            else
            {
                _dialogueManager.Think(command.Character, command.Thought);
            }
        }
    }
}