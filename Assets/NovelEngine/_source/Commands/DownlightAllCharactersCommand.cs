using System.Collections.Generic;
using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(DownlightAllCharactersCommand))]
    public sealed class DownlightAllCharactersCommand : CommandSO, ICommand
    {

        public static DownlightAllCharactersCommand Create(IEnumerable<CharacterSO> characters)
        {
            var inst = ScriptableObject.CreateInstance<DownlightAllCharactersCommand>();
            return inst;
        }
    }
}
