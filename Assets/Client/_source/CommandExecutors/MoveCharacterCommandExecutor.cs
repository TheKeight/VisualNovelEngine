using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class MoveCharacterCommandExecutor : CommandExecutorComponent<MoveCharacterCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Execute(MoveCharacterCommand command)
        {
            _charactersOnSceneManager.ChangePosition(command.Character, command.Position);
        }
    }
}