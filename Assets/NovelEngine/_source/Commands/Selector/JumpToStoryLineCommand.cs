using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(JumpToStoryLineCommand))]
    public sealed class JumpToStoryLineCommand : CommandSO, ICommand
    {
        [SerializeField] private StoryLineSO _storyLine;


        public StoryLineSO StoryLine => _storyLine;


        public static JumpToStoryLineCommand Create(StoryLineSO storyLine)
        {
            var inst = ScriptableObject.CreateInstance<JumpToStoryLineCommand>();
            inst._storyLine = storyLine;
            return inst;
        }
    }
}
