using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(DownlightCharactersCommand))]
    public sealed class DownlightCharactersCommand : CommandSO, ICommand
    {
        [SerializeField] private CharacterSO[] _characters;


        public IReadOnlyList<CharacterSO> Characters => _characters;


        public static DownlightCharactersCommand Create(IEnumerable<CharacterSO> characters)
        {
            var inst = ScriptableObject.CreateInstance<DownlightCharactersCommand>();
            inst._characters = characters.ToArray();
            return inst;
        }
    }
}
