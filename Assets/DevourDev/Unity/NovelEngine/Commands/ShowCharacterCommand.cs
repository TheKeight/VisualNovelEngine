using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{

    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ShowCharacterCommand))]
    public sealed class ShowCharacterCommand : NovelCommand
    {
        [SerializeField] private Character _character;
        [SerializeField] private float _position;
        [SerializeField] private AppearanceKey _appearanceKey;


        public Character Character => _character;
        public float Position => _position;
        public AppearanceKey AppearanceKey => _appearanceKey;


        public static ShowCharacterCommand Create(Character character, float position, AppearanceKey appearanceKey)
        {
            var inst = CreateInstance<ShowCharacterCommand>();
            inst._character = character;
            inst._position = position;
            inst._appearanceKey = appearanceKey;
            return inst;
        }
    }
}
