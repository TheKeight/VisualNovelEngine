using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(JumpToStoryLineCommand))]
    public sealed class JumpToStoryLineCommand : NovelCommand
    {
        [SerializeField] private StoryLine _destination;


        public StoryLine Destination => _destination;


        public static JumpToStoryLineCommand Create(StoryLine destination)
        {
            var inst = CreateInstance<JumpToStoryLineCommand>();
            inst._destination = destination;
            return inst;
        }
    }
}
