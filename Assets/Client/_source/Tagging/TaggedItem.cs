using System.Collections.Generic;
using DevourDev.Unity.Utility.Serialization;
using UnityEngine;

namespace NovelEngine.Tagging
{
    public abstract class TaggedItem<T> : ScriptableObject
    {
        [SerializeField] private T _item;
        [SerializeField] private SerializedHashSet<TagSO> _tags;


        public T Item => _item;
        public IReadOnlyCollection<TagSO> Tags => _tags;


        public bool ContainsTag(TagSO tag)
        {
            return _tags.Contains(tag);
        }
    }
}