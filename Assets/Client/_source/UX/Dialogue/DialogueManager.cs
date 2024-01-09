using TMPro;
using UnityEngine;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Client.UX.Dialogue
{
    public sealed class DialogueManager : MonoBehaviour
    {
        [System.Serializable]
        private sealed class Character : ICharacter
        {
            [SerializeField] private string _name;
            [SerializeField] private TextDesign _nameTextDesign;
            [SerializeField] private TextDesign _dialogueTextDesign;
            [SerializeField] private SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> _appearances;

            public string Name => _name;
            public TextDesign NameTextDesign => _nameTextDesign;
            public TextDesign DialogueTextDesign => _dialogueTextDesign;


            public Sprite GetDefaultAppearance() => _appearances.GetDefaultValue();

            public Sprite GetAppearance(AppearanceKeySO key) => _appearances.GetValueOrDefault(key);
        }


        [SerializeField] private TMP_Text _authorNameText;
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private Character _defaultAuthor;


        //TODO: Implement "typing" effect

        public void Say(ICharacter character, string text)
        {
            character = FixCharacter(character);
            ApplyDesign(character);
            _authorNameText.text = character.Name;
            _dialogueText.text = text;
        }

        public void Think(ICharacter character, string text)
        {
            character = FixCharacter(character);
            ApplyDesign(character);
            _authorNameText.text = $"{character.Name} (мысли)";
            _dialogueText.text = $"*{text}*";
        }

        private ICharacter FixCharacter(ICharacter character)
        {
            return character ?? _defaultAuthor;
        }

        private void ApplyDesign(ICharacter character)
        {
            character.NameTextDesign.Apply(_authorNameText);
            character.DialogueTextDesign.Apply(_dialogueText);
        }
    }
}
