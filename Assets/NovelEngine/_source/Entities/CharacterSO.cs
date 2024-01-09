using UnityEngine;
using VisualNovel.Utility;

namespace VisualNovel.Entities
{
    public interface ICharacter
    {
        string Name { get; }
        TextDesign NameTextDesign { get; }
        TextDesign DialogueTextDesign { get; }


        Sprite GetDefaultAppearance();
        Sprite GetAppearance(AppearanceKeySO key);
    }

    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "Character")]
    public sealed class CharacterSO : ScriptableObject, ICharacter
    {
        [SerializeField] private string _name;
        [SerializeField] private TextDesign _nameTextDesign;
        [SerializeField] private TextDesign _dialogueTextDesign;
        [SerializeField] private SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> _appearances;


        public string Name => _name;
        public TextDesign NameTextDesign => _nameTextDesign;
        public TextDesign DialogueTextDesign => _dialogueTextDesign;


        public static CharacterSO Create(string name, TextDesign nameTextDesign, TextDesign dialogTextDesign,
             SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> appearances)
        {
            var inst = ScriptableObject.CreateInstance<CharacterSO>();
            inst._name = name;
            inst._nameTextDesign = nameTextDesign;
            inst._dialogueTextDesign = dialogTextDesign;
            inst._appearances = appearances;
            return inst;
        }


        public Sprite GetDefaultAppearance() => _appearances.GetDefaultValue();

        public Sprite GetAppearance(AppearanceKeySO key) => _appearances.GetValueOrDefault(key);
    }
}