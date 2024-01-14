using System;
using System.Collections.Generic;
using DevourDev.Unity.Utility.Serialization;
using UnityEngine;

namespace NovelEngine.Tagging
{
    public abstract class TaggedItemsMatrix<T> : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<TagSO, SerializedHashSet<T>> _collection;

        private HashSet<T> _buffer;


        private HashSet<T> Buffer
        {
            get
            {
                _buffer ??= new();
                //_buffer.Clear();
                return _buffer;
            }
        }


        public int Query(ICollection<T> buffer, QueryMode mode, IReadOnlyList<TagSO> includeTags, IReadOnlyList<TagSO> excludeTags)
        {
            return mode switch
            {
                QueryMode.Any => QueryRequireAny(buffer, includeTags, excludeTags),
                QueryMode.All => QueryRequireAll(buffer, includeTags, excludeTags),
                _ => throw new System.NotImplementedException(),
            };
        }


        public int QueryRequireAny(ICollection<T> buffer, params TagSO[] tags)
            => QueryRequireAny(buffer, (IReadOnlyList<TagSO>)tags, null);

        public int QueryRequireAny(ICollection<T> buffer, IReadOnlyList<TagSO> includeTags, IReadOnlyList<TagSO> excludeTags)
        {
            if (includeTags == null)
                return 0;

            int tagsCount = includeTags.Count;

            if (tagsCount == 0)
                return 0;

            var hs = Buffer;

            for (int i = 0; i < tagsCount; i++)
            {
                var tag = includeTags[i];

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

        public int QueryRequireAll(ICollection<T> buffer, params TagSO[] requiredTags)
            => QueryRequireAll(buffer, (IReadOnlyList<TagSO>)requiredTags, null);

        public int QueryRequireAll(ICollection<T> buffer, IReadOnlyList<TagSO> includeTags, IReadOnlyList<TagSO> excludeTags)
        {
            if (includeTags == null)
                return 0;

            int tagsCount = includeTags.Count;

            if (tagsCount == 0)
                return 0;

            var hs = Buffer;

            if (!_collection.TryGetValue(includeTags[0], out var firstCollection))
            {
                return 0;
            }

            foreach (var item in firstCollection)
            {
                hs.Add(item);
            }

            for (int i = 1; i < tagsCount; i++)
            {
                if (!_collection.TryGetValue(includeTags[i], out var nextCollection))
                    return 0;

                hs.IntersectWith(nextCollection);

                if (hs.Count == 0)
                    return 0;
            }

            var count = hs.Count;

            foreach (var item in hs)
            {
                if(ContainsBlackListedTags(item, excludeTags))
                {
                    --count;
                    continue;
                }

                buffer.Add(item);
            }

            hs.Clear();
            return count;
        }

        private bool ContainsBlackListedTags(T item, IReadOnlyList<TagSO> excludeTags)
        {
            foreach (var exTag in excludeTags)
            {
                if (_collection.TryGetValue(exTag, out var collection))
                {
                    if (collection.Contains(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}