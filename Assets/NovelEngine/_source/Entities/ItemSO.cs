using UnityEngine;
using VisualNovel.Utility;

namespace VisualNovel.Entities
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "Item")]
    public sealed class ItemSO : ScriptableObject
    {
        [SerializeField] private SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> _appearances;


        public Sprite GetDefaultAppearance() => _appearances.GetDefaultValue();

        public Sprite GetAppearance(AppearanceKeySO key) => _appearances.GetValueOrDefault(key);
    }
}