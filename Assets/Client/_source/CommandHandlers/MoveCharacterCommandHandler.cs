using NovelEngine.Commands;
using NovelEngine.UX.ItemsOnScene;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class MoveCharacterCommandHandler : CommandHandlerComponent<MoveCharacterCommand>
    {
        [SerializeField] private CharactersOnSceneManager _charactersOnSceneManager;


        public override void Handle(MoveCharacterCommand command)
        {
            _charactersOnSceneManager.ChangePosition(command.Character, command.Position);
        }
    }
}