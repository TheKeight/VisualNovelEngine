using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Entities;
using NovelEngine.Tagging;
using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    public sealed class CharactersOnSceneManager : MonoBehaviour
    {
        [SerializeField] private PositionManager _positionManager;
        [SerializeField] private CharacterViewModelsProvider _characterViewModelsProvider;
        [SerializeField] private float _moveTime = 0.4f;

        private readonly Dictionary<Character, CharacterOnScene> _charactersOnScene = new();


        public void Show(Character character, AppearanceKey appearanceKey, float position)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
            {
                characterOnScene = RentCharacterOnSceneInstance(character, appearanceKey, position);
                _charactersOnScene[character] = characterOnScene;
            }
        }

        public void Show(Character character, float position, QueryMode queryMode, IReadOnlyList<TagSO> tags, IReadOnlyList<TagSO> blackListTags)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
            {
                characterOnScene = RentCharacterOnSceneInstance(character, position, queryMode, tags, blackListTags);
                _charactersOnScene[character] = characterOnScene;
            }
        }

        public void Hide(Character character)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            _charactersOnScene.Remove(character);

            ReturnCharacterOnSceneInstance(characterOnScene);
        }

        public void ChangeAppearance(Character character, AppearanceKey appearanceKey)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            characterOnScene.ChangeAppearance(appearanceKey);
        }

        public void ChangeAppearance(Character character, QueryMode mode, IReadOnlyList<TagSO> tags,
            IReadOnlyList<TagSO> blackListTags)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            characterOnScene.ChangeAppearance(mode, tags, blackListTags);
        }

        public void ChangePosition(Character character, float position)
        {
            if (!_charactersOnScene.TryGetValue(character, out var characterOnScene))
                return;

            characterOnScene.ChangePosition(position, _moveTime);
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

        private CharacterOnScene RentCharacterOnSceneInstance(Character character, AppearanceKey appearanceKey, float position)
        {
            var instance = _characterViewModelsProvider.RentInstance(character);
            instance.Init(character, _positionManager, position, _moveTime, appearanceKey);
            return instance;
        }

        private CharacterOnScene RentCharacterOnSceneInstance(Character character, float position,
            QueryMode queryMode, IReadOnlyList<TagSO> tags, IReadOnlyList<TagSO> blackListTags)
        {
            var instance = _characterViewModelsProvider.RentInstance(character);
            instance.Init(character, _positionManager, position, _moveTime, queryMode, tags, blackListTags);
            return instance;
        }

        private void ReturnCharacterOnSceneInstance(CharacterOnScene characterOnScene)
        {
            _characterViewModelsProvider.ReturnInstance(characterOnScene);
        }
    }
}