using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;
using NovelEngine.Entities;

namespace NovelEngine.UX.ItemsOnScene
{
    public sealed class SimpleCharacterOnScene : CharacterOnScene
    {
        [SerializeField] private SpriteRenderer _sr;

        private Character _reference;
        private AppearanceKey _appearanceKey;


        public override Character Reference => _reference;

        public override AppearanceKey AppearanceKey
        {
            get => _appearanceKey;
            set
            {
                _appearanceKey = value;
                throw new System.NotImplementedException();
                //_sr.sprite = _reference.GetAppearance(_appearanceKey);
            }
        }


        public override void Init(Character reference, AppearanceKey appearanceKey)
        {
            _reference = reference;
            AppearanceKey = appearanceKey;
        }
    }
}