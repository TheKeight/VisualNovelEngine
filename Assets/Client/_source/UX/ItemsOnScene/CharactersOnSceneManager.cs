﻿using System;
using System.Collections.Generic;
using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    public sealed class CharactersOnSceneManager : MonoBehaviour
    {
        [SerializeField] private PositionManager _positionManager;
        [SerializeField] private CharacterViewModelsProvider _characterViewModelsProvider;

        private readonly Dictionary<CharacterSO, CharacterOnScene> _charactersOnScene = new();


        public void Show(CharacterSO character, AppearanceKeySO appearanceKey, ScenePositionSO position)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
            {
                characterOnScene = RentCharacterOnSceneInstance(character);
                _charactersOnScene[character] = characterOnScene;
            }

            characterOnScene.AppearanceKey = appearanceKey;
            _positionManager.ChangePosition(characterOnScene.transform, position);
        }

        public void Hide(CharacterSO character)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            ReturnCharacterOnSceneInstance(characterOnScene);
        }

        public void ChangeAppearance(CharacterSO character, AppearanceKeySO appearanceKey)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            characterOnScene.AppearanceKey = appearanceKey;
        }

        public void ChangePosition(CharacterSO character, ScenePositionSO position)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;
        }

        public void Highlight(IEnumerable<CharacterSO> characters)
        {
            throw new System.NotImplementedException();
        }

        public void Downlight(IEnumerable<CharacterSO> characters)
        {
            throw new System.NotImplementedException();
        }

        public void DownlightAll()
        {
            throw new System.NotImplementedException();
        }

        private CharacterOnScene RentCharacterOnSceneInstance(CharacterSO character)
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