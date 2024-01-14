using System.Collections.Generic;
using System.Linq;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Tagging;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ShowCharacterWithTagsCommand))]
    public sealed class ShowCharacterWithTagsCommand : NovelCommand
    {
        [SerializeField] private Character _character;
        [SerializeField] private float _position;
        [SerializeField] private TagSO[] _tags;
        [SerializeField] private TagSO[] _blackListTags;
        [SerializeField] private QueryMode _queryMode;


        public Character Character => _character;
        public float Position => _position;
        public IReadOnlyList<TagSO> Tags => _tags;
        public IReadOnlyList<TagSO> BlackListTags => _blackListTags;
        public QueryMode QueryMode => _queryMode;


        public static ShowCharacterWithTagsCommand Create(Character character, float position,
            QueryMode queryMode, IEnumerable<TagSO> tags, IEnumerable<TagSO> blackListTags)
        {
            var inst = CreateInstance<ShowCharacterWithTagsCommand>();
            inst._character = character;
            inst._position = position;
            inst._tags = tags.ToArray();
            inst._blackListTags = blackListTags == null ? null : blackListTags.ToArray();
            inst._queryMode = queryMode;
            return inst;
        }
    }
}
