using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(Think))]
    public sealed class Think : NovelCommand
    {
        [field: SerializeField] public Character Character { get; private set; }
        [field: SerializeField] public string Thought { get; private set; }


        public static Think Create(Character character, string thought)
        {
            var inst = CreateInstance<Think>();
            inst.Character = character;
            inst.Thought = thought;
            return inst;
        }
    }


}
