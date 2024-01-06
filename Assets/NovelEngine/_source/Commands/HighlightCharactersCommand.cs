using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(HighlightCharactersCommand))]
    public sealed class HighlightCharactersCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO[] _characters;


        public IReadOnlyList<CharacterSO> Characters => _characters;


        public static HighlightCharactersCommand Create(IEnumerable<CharacterSO> characters)
        {
            var inst = ScriptableObject.CreateInstance<HighlightCharactersCommand>();
            inst._characters = characters.ToArray();
            return inst;
        }
    }
}
