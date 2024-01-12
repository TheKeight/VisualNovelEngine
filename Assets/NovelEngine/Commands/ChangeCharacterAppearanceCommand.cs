using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ChangeCharacterAppearanceCommand))]
    public sealed class ChangeCharacterAppearanceCommand : NovelCommand
    {
        [SerializeField] private Character _character;
        [SerializeField] private AppearanceKey _appearanceKey;


        public Character Character => _character;
        public AppearanceKey AppearanceKey => _appearanceKey;

        public static ChangeCharacterAppearanceCommand Create(Character character, AppearanceKey appearanceKey)
        {
            var inst = CreateInstance<ChangeCharacterAppearanceCommand>();
            inst._character = character;
            inst._appearanceKey = appearanceKey;
            return inst;
        }
    }


}
