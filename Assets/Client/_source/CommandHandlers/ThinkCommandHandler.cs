using NovelEngine.Commands;
using UnityEngine;
using NovelEngine.CommandHandlers.UX.Dialogue;

namespace NovelEngine.CommandHandlers
{
    public sealed class ThinkCommandHandler : CommandHandlerComponent<Think>
    {
        [SerializeField] private DialogueManager _dialogueManager;


        public override void Handle(Think command)
        {
            UnityEngine.Debug.LogError("not implemented");

            //_dialogueManager.Think(command.Character, command.Text);
        }
    }
}