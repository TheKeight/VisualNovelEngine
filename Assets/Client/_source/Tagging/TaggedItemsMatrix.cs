using System.Collections.Generic;
using DevourDev.Unity.Utility.Serialization;
using UnityEngine;

namespace NovelEngine.Tagging
{
    //TODO: избавиться от TaggedItem<T> (просто заполняешь матрицу - и всё),
    // но нужен поиск по T (а зачем?)
    public abstract class TaggedItemsMatrix<T, TItem> : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<TagSO, SerializedHashSet<TItem>> _collection;

        private HashSet<TItem> _buffer;


        private HashSet<TItem> Buffer
        {
            get
            {
                _buffer ??= new();
                //_buffer.Clear();
                return _buffer;
            }
        }


        public int Query(ICollection<TItem> buffer, IReadOnlyList<TagSO> tags, QueryMode mode)
        {
            return mode switch
            {
                QueryMode.Any => QueryRequireAny(buffer, tags),
                QueryMode.All => QueryRequireAll(buffer, tags),
                _ => throw new System.NotImplementedException(),
            };
        }


        public int QueryRequireAny(ICollection<TItem> buffer, params TagSO[] tags)
            => QueryRequireAny(buffer, (IReadOnlyList<TagSO>)tags);

        public int QueryRequireAny(ICollection<TItem> buffer, IReadOnlyList<TagSO> tags)
        {
            if (tags == null)
                return 0;

            int tagsCount = tags.Count;

            if (tagsCount == 0)
                return 0;

            var hs = Buffer;

            for (int i = 0; i < tagsCount; i++)
            {
                var tag = tags[i];

                if (!_collection.TryGetValue(tag, out var items))
                    continue;

                hs.UnionWith(items);
            }

            foreach (var item in hs)
            {
                buffer.Add(item);
            }

            int count = hs.Count;
            hs.Clear();
            return count;
        }

        public int QueryRequireAll(ICollection<TItem> buffer, params TagSO[] requiredTags)
            => QueryRequireAll(buffer, (IReadOnlyList<TagSO>)requiredTags);

        public int QueryRequireAll(ICollection<TItem> buffer, IReadOnlyList<TagSO> requiredTags)
        {
            if (requiredTags == null)
                return 0;

            int tagsCount = requiredTags.Count;

            if (tagsCount == 0)
                return 0;

            var hs = Buffer;

            if (!_collection.TryGetValue(requiredTags[0], out var firstCollection))
            {
                return 0;
            }

            foreach (var item in firstCollection)
            {
                hs.Add(item);
            }

            for (int i = 1; i < tagsCount; i++)
            {
                if (!_collection.TryGetValue(requiredTags[i], out var nextCollection))
                    return 0;

                hs.IntersectWith(nextCollection);

                if (hs.Count == 0)
                    return 0;
            }

            var count = hs.Count;

            foreach (var item in hs)
            {
                buffer.Add(item);
            }

            hs.Clear();
            return count;
        }
    }
}