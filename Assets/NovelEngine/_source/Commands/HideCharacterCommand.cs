using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{

    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(HideCharacterCommand))]
    public sealed class HideCharacterCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO _character;


        public CharacterSO Character => _character;


        public static HideCharacterCommand Create(CharacterSO character)
        {
            var inst = ScriptableObject.CreateInstance<HideCharacterCommand>();
            inst._character = character;
            return inst;
        }
    }
}
