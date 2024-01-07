using UnityEngine;
using VisualNovel.Utility;

namespace VisualNovel.Entities
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "Character")]
    public sealed class CharacterSO : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private TextDesign _nameTextDesign;
        [SerializeField] private TextDesign _dialogTextDesign;
        [SerializeField] private SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> _appearances;


        public string Name => _name;
        public TextDesign NameTextDesign => _nameTextDesign;
        public TextDesign DialogTextDesign => _dialogTextDesign;


        public static CharacterSO Create(string name, TextDesign nameTextDesign, TextDesign dialogTextDesign,
             SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> appearances)
        {
            var inst = ScriptableObject.CreateInstance<CharacterSO>();
            inst._name = name;
            inst._nameTextDesign = nameTextDesign;
            inst._dialogTextDesign = dialogTextDesign;
            inst._appearances = appearances;
            return inst;
        }


        public Sprite GetDefaultAppearance() => _appearances.GetDefaultValue();

        public Sprite GetAppearance(AppearanceKeySO key) => _appearances.GetValueOrDefault(key);
    }
}