using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{

    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ChangeCharacterAppearanceCommand))]
    public sealed class ChangeCharacterAppearanceCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO _character;
        [SerializeField] private AppearanceKeySO _appearanceKey;


        public CharacterSO Character => _character;
        public AppearanceKeySO AppearanceKey => _appearanceKey;


        public static ChangeCharacterAppearanceCommand Create(CharacterSO character,
            AppearanceKeySO appearanceKey)
        {
            var inst = ScriptableObject.CreateInstance<ChangeCharacterAppearanceCommand>();
            inst._character = character;
            inst._appearanceKey = appearanceKey;
            return inst;
        }
    }
}
