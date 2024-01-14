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
            _position = position;
            ChangeAppearance(0, 0, 0, 1, moveTime, appearanceKey);
            var targetPos = _positionManager.GetWorldPosition(position);
            var fromPos = targetPos + _enterPosDelta;
            transform.position = fromPos;
            ChangePosition(fromPos, targetPos, moveTime);
        }

        public override void Init(Character reference, PositionManager positionManager,
            float position, float moveTime, QueryMode queryMode, IReadOnlyList<TagSO> tags, IReadOnlyList<TagSO> blackListTags)
        {
            _reference = reference;
            _positionManager = positionManager;
            _position = position;
            ChangeAppearance(0, 0, 0, 1, moveTime, queryMode, tags, blackListTags);
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

        public void ChangeAppearance(float a1From, float a1To,
            float a2From, float a2To, float time,
            QueryMode queryMode, IReadOnlyList<TagSO> tags, IReadOnlyList<TagSO> blackListTags)
        {
            _appearanceKey = _appearancesProvider.QueryAppearance(_reference, queryMode, tags, blackListTags);
            ChangeSprite(a1From, a1To, a2From, a2To, time, _appearancesProvider.GetSprite(_reference, _appearanceKey));
        }

        public void ChangeAppearance(float a1From, float a1To,
            float a2From, float a2To, float time,
            AppearanceKey appearanceKey)
        {
            _appearanceKey = appearanceKey;
            ChangeSprite(a1From, a1To, a2From, a2To, time, _appearancesProvider.GetSprite(_reference, _appearanceKey));
        }

        public override void ChangeAppearance(QueryMode mode, IReadOnlyList<TagSO> tags, IReadOnlyList<TagSO> blackListTags)
        {
            ChangeAppearance(_appearancesProvider.QueryAppearance(_reference, mode, tags, blackListTags));
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

            var enumerator = GetChangeSpriteRoutine(1, 0, 0, 1, _fadeTime, newSprite);
            _changingSpriteRoutine = StartCoroutine(enumerator);
        }

        private void ChangeSprite(float a1From, float a1To,
            float a2From, float a2To,
            float time,
            Sprite sprite)
        {
            if (_changingSpriteRoutine != null)
            {
                StopCoroutine(_changingSpriteRoutine);
                _changingSpriteRoutine = null;
            }

            var enumerator = GetChangeSpriteRoutine(a1From, a1To, a2From, a2To, time, sprite);
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

        private IEnumerator GetChangeSpriteRoutine(float a1From, float a1To,
            float a2From, float a2To,
            float time,
            Sprite sprite)
        {
            var color1 = _sr1.color;
            var color2 = _sr2.color;
            color1.a = a1From;
            color2.a = a2From;
            _sr1.color = color1;
            _sr2.color = color2;
            _sr2.sprite = sprite;

            for (float timeLeft = time; (timeLeft -= Time.deltaTime) > 0;)
            {
                float t = 1f - timeLeft / time;

                color1.a = Mathf.Lerp(a1From, a1To, t);
                color2.a = Mathf.Lerp(a2From, a2To, t);
                _sr1.color = color1;
                _sr2.color = color2;

                yield return null;
            }

            color1.a = a1To;
            color2.a = a2To;
            _sr1.color = color1;
            _sr2.color = color2;

            (_sr1, _sr2) = (_sr2, _sr1);
        }
    }
}