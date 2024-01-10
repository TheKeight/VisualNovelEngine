using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Engine;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class JumpToStoryLineCommandExecutor : CommandExecutorComponent<JumpToStoryLineCommand>
    {
        [SerializeField] private NovelControllerComponent _novelController;


        public override void Execute(JumpToStoryLineCommand command)
        {
            _novelController.SetStoryLine(command.StoryLine, 0);    
        }
    }
}