using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisualNovel.Commands;

namespace VisualNovel.Entities
{

    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "StoryLine")]
    public sealed class StoryLineSO : ScriptableObject, IStoryLine
    {
        [SerializeField] private CommandSO[] _commands;


        public IReadOnlyList<CommandSO> Commands => _commands;


        public static StoryLineSO Create(IEnumerable<CommandSO> commands)
        {
            var inst = ScriptableObject.CreateInstance<StoryLineSO>();
            inst._commands = commands.ToArray();
            return inst;
        }
    }
}