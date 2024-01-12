using NovelEngine.CommandHandlers.UX.Dialogue;
using NovelEngine.Commands;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class ThinkCommandHandler : CommandHandlerComponent<Think>
    {
        [SerializeField] private DialogueManager _dialogueManager;


        public override void Handle(Think command)
        {
            _dialogueManager.Think(command.Character, command.Thought);
        }
    }
}