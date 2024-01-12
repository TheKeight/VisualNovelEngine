using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Core;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class JumpToStoryLineCommandHandler : CommandHandlerComponent<JumpToStoryLineCommand>
    {
        [SerializeField] private NovelControllerComponent _novelController;


        public override void Handle(JumpToStoryLineCommand command)
        {
            _novelController.SetStoryLine(command.Destination, 0);
        }
    }
}