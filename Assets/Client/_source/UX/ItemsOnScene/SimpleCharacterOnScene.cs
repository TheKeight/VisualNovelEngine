using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    public sealed class SimpleCharacterOnScene : CharacterOnScene
    {
        [SerializeField] private SpriteRenderer _sr;

        private CharacterSO _reference;
        private AppearanceKeySO _appearanceKey;


        public override CharacterSO Reference => _reference;

        public override AppearanceKeySO AppearanceKey
        {
            get => _appearanceKey;
            set
            {
                _appearanceKey = value;
                _sr.sprite = _reference.GetAppearance(_appearanceKey);
            }
        }


        public override void Init(CharacterSO reference, AppearanceKeySO appearanceKey)
        {
            _reference = reference;
            AppearanceKey = appearanceKey;
        }
    }
}