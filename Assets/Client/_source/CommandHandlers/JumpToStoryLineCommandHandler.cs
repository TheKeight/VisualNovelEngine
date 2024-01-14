using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Core;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class JumpToStoryLineCommandHandler : CommandHandlerComponent<JumpToStoryLineCommand>
    {
        [SerializeField] private NovelControllerComponent _novelController;


        public void Jump(StoryLine storyLine, int startIndex = 0)
        {
            _novelController.SetStoryLine(storyLine, startIndex);
        }

        public override void Handle(JumpToStoryLineCommand command)
        {
            Jump(command.Destination, 0);
        }
    }
}