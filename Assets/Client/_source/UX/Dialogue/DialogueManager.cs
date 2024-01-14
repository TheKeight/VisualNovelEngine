using System.Collections;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.Utility.UI;
using TMPro;
using UnityEngine;

namespace NovelEngine.UX.Dialogue
{
    public sealed class DialogueManager : MonoBehaviour
    {
        [System.Serializable]
        private sealed class Character : ICharacter
        {
            [SerializeField] private string _name;
            [SerializeField] private TextMeshProDesign _nameTextDesign;
            [SerializeField] private TextMeshProDesign _dialogueTextDesign;


            public string CharacterName => _name;
            public TextMeshProDesign NameTextDesign => _nameTextDesign;
            public TextMeshProDesign SpeechTextDesign => _dialogueTextDesign;
        }


        [SerializeField] private TMP_Text _authorNameText;
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private Character _defaultAuthor;
        [SerializeField] private float _symbolsPerSecond = 35f;

        private string _message;
        private Coroutine _textRevealing;

        //TODO: Implement "typing" effect

        public void Say(string name, string text)
        {
            var character = _defaultAuthor;
            ApplyDesign(character);
            _authorNameText.text = name;
            RevealText(text);
        }

        public void Say(ICharacter character, string text)
        {
            character = FixCharacter(character);
            ApplyDesign(character);
            _authorNameText.text = character.CharacterName;
            RevealText(text);
        }

        public void Think(string name, string text)
        {
            var character = _defaultAuthor;
            ApplyDesign(character);
            _authorNameText.text = $"{name} (мысли)";
            RevealText($"*{text}*");
        }

        public void Think(ICharacter character, string text)
        {
            character = FixCharacter(character);
            ApplyDesign(character);
            _authorNameText.text = $"{character.CharacterName} (мысли)";
            RevealText($"*{text}*");
        }


        public void SkipRevealing()
        {
            _dialogueText.maxVisibleCharacters = _message.Length;
            _dialogueText.text = _message;
        }

        private void RevealText(string text)
        {
            _message = text;

            if (_textRevealing != null)
            {
                StopCoroutine(_textRevealing);
            }

            _textRevealing = StartCoroutine(RevealCharacters(_dialogueText, _message));
        }

        private IEnumerator RevealCharacters(TMP_Text textComponent, string text)
        {
            textComponent.text = text;
            textComponent.ForceMeshUpdate();

            int totalVisibleCharacters = text.Length;

            float visibleFloat = 0;
            textComponent.maxVisibleCharacters = 0;

            for (int visibleCount = 0; visibleCount < totalVisibleCharacters;)
            {
                visibleFloat += _symbolsPerSecond * Time.deltaTime;
                int tmp = visibleCount;
                visibleCount = (int)visibleFloat;

                if (tmp != visibleCount)
                    textComponent.maxVisibleCharacters = visibleCount;

                yield return null;
            }

            _textRevealing = null;
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
