using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{

    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ShowCharacterCommand))]
    public sealed class ShowCharacterCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO _character;
        [SerializeField] private ScenePositionSO _position;
        [SerializeField] private AppearanceKeySO _appearanceKey;


        public CharacterSO Character => _character;
        public ScenePositionSO Position => _position;
        public AppearanceKeySO AppearanceKey => _appearanceKey;


        public static ShowCharacterCommand Create(CharacterSO character,
            ScenePositionSO scenePosition, AppearanceKeySO appearanceKey)
        {
            var inst = ScriptableObject.CreateInstance<ShowCharacterCommand>();
            inst._character = character;
            inst._position = scenePosition;
            inst._appearanceKey = appearanceKey;
            return inst;
        }
    }
}
