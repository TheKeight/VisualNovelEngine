using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.Utility.UI;
using TMPro;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX.Dialogue
{
    public sealed class DialogueManager : MonoBehaviour
    {
        [System.Serializable]
        private sealed class Character : ICharacter
        {
            [SerializeField] private string _name;
            [SerializeField] private TextMeshProDesign _nameTextDesign;
            [SerializeField] private TextMeshProDesign _dialogueTextDesign;
            //[SerializeField] private SerializedDictionaryWithDefaultValue<AppearanceKeySO, Sprite> _appearances;

            public string CharacterName => _name;
            public TextMeshProDesign NameTextDesign => _nameTextDesign;
            public TextMeshProDesign SpeechTextDesign => _dialogueTextDesign;


            //public Sprite GetDefaultAppearance() => _appearances.GetDefaultValue();

            //public Sprite GetAppearance(AppearanceKeySO key) => _appearances.GetValueOrDefault(key);
        }


        [SerializeField] private TMP_Text _authorNameText;
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private Character _defaultAuthor;


        //TODO: Implement "typing" effect

        public void Say(ICharacter character, string text)
        {
            character = FixCharacter(character);
            ApplyDesign(character);
            _authorNameText.text = character.CharacterName;
            _dialogueText.text = text;
        }

        public void Think(ICharacter character, string text)
        {
            character = FixCharacter(character);
            ApplyDesign(character);
            _authorNameText.text = $"{character.CharacterName} (мысли)";
            _dialogueText.text = $"*{text}*";
        }

        private ICharacter FixCharacter(ICharacter character)
        {
            return character ?? _defaultAuthor;
        }

        private void ApplyDesign(ICharacter character)
        {
            character.NameTextDesign.Apply(_authorNameText);
            character.SpeechTextDesign.Apply(_dialogueText);
        }
    }
}
