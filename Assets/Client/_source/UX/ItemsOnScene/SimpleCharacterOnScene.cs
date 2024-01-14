using System.Collections;
using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Entities;
using NovelEngine.Tagging;
using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    public sealed class SimpleCharacterOnScene : CharacterOnScene
    {
        [SerializeField] private SimpleCharacterAppearancesProvider _appearancesProvider;
        [SerializeField] private SpriteRenderer _sr1;
        [SerializeField] private SpriteRenderer _sr2;
        [SerializeField] private float _fadeTime = 0.3f;
        [SerializeField] private Vector3 _enterPosDelta = Vector3.down * 1.5f;

        private Character _reference;
        private AppearanceKey _appearanceKey;
        private float _position;
        private PositionManager _positionManager;

        private Coroutine _changingSpriteRoutine;
        private Coroutine _changingPositionRoutine;


        public override Character Reference => _reference;
        public override AppearanceKey AppearanceKey => _appearanceKey;
        public override float Position => _position;


        public override void Init(Character reference, PositionManager positionManager,
            float position, float moveTime, AppearanceKey appearanceKey)
        {
            _reference = reference;
            _positionManager = positionManager;
            ChangeAppearance(appearanceKey);
            var targetPos = _positionManager.GetWorldPosition(position);
            var fromPos = targetPos - _enterPosDelta;
            transform.position = fromPos;
            ChangePosition(fromPos, targetPos, moveTime);
        }

        public override void ChangeAppearance(AppearanceKey appearanceKey)
        {
            _appearanceKey = appearanceKey;
            ChangeSprite(_appearancesProvider.GetSprite(_reference, _appearanceKey));
        }

        public override void ChangeAppearance(IReadOnlyList<TagSO> tags, QueryMode mode)
        {
            ChangeAppearance(_appearancesProvider.QueryAppearance(_reference, tags, mode));
        }

        public override void ChangePosition(float targetPosition, float time)
        {
            if (_changingPositionRoutine != null)
            {
                StopCoroutine(_changingPositionRoutine);
                _changingPositionRoutine = null;
            }

            float fromPos = _position;
            _position = targetPosition;
            var enumerator = GetChangePositionRoutine(fromPos, targetPosition, time);
            _changingPositionRoutine = StartCoroutine(enumerator);
        }

        private void ChangePosition(Vector3 fromPos, Vector3 targetPosition, float time)
        {
            if (_changingPositionRoutine != null)
            {
                StopCoroutine(_changingPositionRoutine);
                _changingPositionRoutine = null;
            }

            var enumerator = GetChangePositionRoutine(fromPos, targetPosition, time);
            _changingPositionRoutine = StartCoroutine(enumerator);
        }

        private void ChangeAppearanceImmediate(AppearanceKey appearanceKey)
        {
            ChangeSpriteImmediate(_appearancesProvider.GetSprite(_reference, appearanceKey));
        }

        private void ChangeSpriteImmediate(Sprite sprite)
        {
            if (_changingSpriteRoutine != null)
            {
                StopCoroutine(_changingSpriteRoutine);
                _changingSpriteRoutine = null;
            }

            _sr1.sprite = sprite;
            var color = _sr1.color;
            color.a = 1;
            _sr1.color = color;
            color = _sr2.color;
            color.a = 0;
            _sr2.color = color;
        }

        private void ChangePositionImmediate(float position)
        {
            _position = position;
            ChangePositionImmediate(_positionManager.GetWorldPosition(position));
        }

        private void ChangePositionImmediate(Vector3 position)
        {
            transform.position = position;
        }

        private void ChangeSprite(Sprite newSprite)
        {
            if (_changingSpriteRoutine != null)
            {
                StopCoroutine(_changingSpriteRoutine);
                _changingSpriteRoutine = null;
            }

            var enumerator = GetChangeSpriteRoutine(newSprite);
            _changingSpriteRoutine = StartCoroutine(enumerator);
        }

        private IEnumerator GetChangePositionRoutine(Vector3 formPosition, Vector3 targetPosition, float time)
        {
            for (float timeLeft = time; (timeLeft -= Time.deltaTime) > 0;)
            {
                float t = 1f - timeLeft / time;
                transform.position = Vector3.Lerp(formPosition, targetPosition, t);
                yield return null;
            }

            transform.position = targetPosition;
        }

        private IEnumerator GetChangePositionRoutine(float fromPosition, float targetPosition, float time)
        {
            for (float timeLeft = time; (timeLeft -= Time.deltaTime) > 0;)
            {
                float t = 1f - timeLeft / time;
                transform.position = _positionManager.GetWorldPosition(Mathf.Lerp(fromPosition, targetPosition, t));
                yield return null;
            }

            transform.position = _positionManager.GetWorldPosition(targetPosition);
        }

        private IEnumerator GetChangeSpriteRoutine(Sprite sprite)
        {
            var color1 = _sr1.color;
            var color2 = _sr2.color;
            color1.a = 1f;
            color2.a = 0f;
            _sr1.color = color1;
            _sr2.color = color2;
            _sr2.sprite = sprite;

            for (float timeLeft = _fadeTime; (timeLeft -= Time.deltaTime) > 0;)
            {
                float t = 1f - timeLeft / _fadeTime;

                color1.a = t;
                color2.a = 1f - t;
                _sr1.color = color1;
                _sr2.color = color2;

                yield return null;
            }

            color1.a = 0f;
            color2.a = 1f;
            _sr1.color = color1;
            _sr2.color = color2;

            (_sr1, _sr2) = (_sr2, _sr1);
        }
    }
}