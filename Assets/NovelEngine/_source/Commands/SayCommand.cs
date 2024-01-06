using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(SayCommand))]
    public sealed class SayCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO _character;
        [SerializeField] private string _text;


        public CharacterSO Character => _character;
        public string Text => _text;


        public static SayCommand Create(CharacterSO character, string text)
        {
            var inst = ScriptableObject.CreateInstance<SayCommand>();
            inst._character = character;
            inst._text = text;
            return inst;
        }
    }
}
