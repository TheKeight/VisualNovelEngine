using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.Utility.Serialization;
using NovelEngine.Entities;
using NovelEngine.Tagging;
using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    [CreateAssetMenu(menuName = "UX/SimpleCharacterAppearancesProvider")]
    public sealed class SimpleCharacterAppearancesProvider : ScriptableObject
    {
        [SerializeField] private TaggedAppearancesMatrix _appearancesMatrix;
        [SerializeField] private AppearanceKey _defaultAppearance;
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private SerializedDictionary<Character, SerializedDictionaryWithDefaultValue<AppearanceKey, Sprite>> _dict;

        private List<AppearanceKey> _appearancesBuffer;


        private List<AppearanceKey> AppearancesBuffer
        {
            get
            {
                _appearancesBuffer ??= new();
                return _appearancesBuffer;
            }
        }


        public Sprite GetSprite(Character character, AppearanceKey appearanceKey)
        {
            if (!_dict.TryGetValue(character, out var spritesDict))
                return _defaultSprite;

            var sprite = spritesDict.GetValueOrDefault(appearanceKey);
            return sprite;
        }

        public AppearanceKey QueryAppearance(Character character, QueryMode mode, IReadOnlyList<TagSO> includeTags, IReadOnlyList<TagSO> excludeTags)
        {
            if (!_dict.TryGetValue(character, out var charDict))
                return _defaultAppearance;

            var buffer = AppearancesBuffer;
            _appearancesMatrix.Query(buffer, mode, includeTags, excludeTags);

            for (int i = buffer.Count - 1; i >= 0; i--)
            {
                if (charDict.ContainsKey(buffer[i]))
                    continue;

                buffer.RemoveAt(i);
            }

            if (buffer.Count == 0)
                return _defaultAppearance;

            var appKey = buffer[UnityEngine.Random.Range(0, buffer.Count)];
            buffer.Clear();
            return appKey;
        }
    }
}