using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(MoveCharacterCommand))]
    public sealed class MoveCharacterCommand : NovelCommand
    {
        [field: SerializeField] public Character Character { get; private set; }
        [field: SerializeField] public float Position { get; private set; }


        public static MoveCharacterCommand Create(Character character, float position)
        {
            var inst = CreateInstance<MoveCharacterCommand>();
            inst.Character = character;
            inst.Position = position;
            return inst;
        }
    }


}
