using System;
using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;
using NovelEngine.Entities;

namespace NovelEngine.CommandHandlers.UX
{
    public sealed class CharactersOnSceneManager : MonoBehaviour
    {
        [SerializeField] private PositionManager _positionManager;
        [SerializeField] private CharacterViewModelsProvider _characterViewModelsProvider;

        private readonly Dictionary<Character, CharacterOnScene> _charactersOnScene = new();


        public void Show(Character character, AppearanceKey appearanceKey, float position)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
            {
                characterOnScene = RentCharacterOnSceneInstance(character);
                _charactersOnScene[character] = characterOnScene;
            }

            characterOnScene.AppearanceKey = appearanceKey;
            _positionManager.ChangePosition(characterOnScene.transform, position);
        }

        public void Hide(Character character)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            ReturnCharacterOnSceneInstance(characterOnScene);
        }

        public void ChangeAppearance(Character character, AppearanceKey appearanceKey)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            characterOnScene.AppearanceKey = appearanceKey;
        }

        public void ChangePosition(Character character, float position)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            throw new NotImplementedException();
        }

        public void Highlight(IEnumerable<Character> characters)
        {
            throw new System.NotImplementedException();
        }

        public void Downlight(IEnumerable<Character> characters)
        {
            throw new System.NotImplementedException();
        }

        public void DownlightAll()
        {
            throw new System.NotImplementedException();
        }

        private CharacterOnScene RentCharacterOnSceneInstance(Character character)
        {
            var instance = _characterViewModelsProvider.RentInstance(character);
            instance.Init(character, null);
            return instance;
        }

        private void ReturnCharacterOnSceneInstance(CharacterOnScene characterOnScene)
        {
            _characterViewModelsProvider.ReturnInstance(characterOnScene);
        }
    }
}