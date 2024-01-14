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

        private List<TaggedAppearance> _appearancesBuffer;


        private List<TaggedAppearance> AppearancesBuffer
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

        public AppearanceKey QueryAppearance(Character character, IReadOnlyList<TagSO> tags, QueryMode mode)
        {
            if (!_dict.TryGetValue(character, out var charDict))
                return _defaultAppearance;

            var buffer = AppearancesBuffer;
            _appearancesMatrix.Query(buffer, tags, mode);

            for (int i = buffer.Count - 1; i >= 0; i--)
            {
                if (charDict.ContainsKey(buffer[i].Item))
                    continue;

                buffer.RemoveAt(i);
            }

            var appKey = buffer[UnityEngine.Random.Range(0, buffer.Count)];
            buffer.Clear();
            return appKey.Item;
        }
    }
}