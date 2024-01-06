using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(MoveCharacterCommand))]
    public sealed class MoveCharacterCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO _character;
        [SerializeField] private ScenePositionSO _position;


        public CharacterSO Character => _character;
        public ScenePositionSO Position => _position;


        public static MoveCharacterCommand Create(CharacterSO character, ScenePositionSO position)
        {
            var inst = CreateInstance<MoveCharacterCommand>();
            inst._character = character;
            inst._position = position;
            return inst;
        }
    }
}
