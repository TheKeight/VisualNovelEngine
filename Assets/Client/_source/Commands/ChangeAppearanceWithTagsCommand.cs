using System.Collections.Generic;
using System.Linq;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Tagging;
using UnityEngine;

namespace NovelEngine.Commands
{
    public sealed class ChangeAppearanceWithTagsCommand : NovelCommand
    {
        [SerializeField] private Character _character;
        [SerializeField] private TagSO[] _tags;
        [SerializeField] private QueryMode _mode;


        public Character Character => _character;
        public IReadOnlyList<TagSO> Tags => _tags;
        public QueryMode Mode => _mode;


        public static ChangeAppearanceWithTagsCommand Create(Character character,
            IEnumerable<TagSO> tags, QueryMode mode)
        {
            var inst = CreateInstance<ChangeAppearanceWithTagsCommand>();
            inst._character = character;
            inst._tags = tags.ToArray();
            inst._mode = mode;
            return inst;
        }
    }
}
