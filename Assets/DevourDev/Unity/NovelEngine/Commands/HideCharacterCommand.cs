using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(HideCharacterCommand))]
    public sealed class HideCharacterCommand : NovelCommand
    {
        [SerializeField] private Character _character;


        public Character Character => _character;


        public static HideCharacterCommand Create(Character character)
        {
            var inst = CreateInstance<HideCharacterCommand>();
            inst._character = character;
            return inst;
        }
    }
}
