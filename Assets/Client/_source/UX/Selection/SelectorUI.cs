using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Core;
using DevourDev.Unity.NovelEngine.Entities;
using TMPro;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX.Selection
{
    internal sealed class SelectorUI : MonoBehaviour
    {
        [SerializeField] private GameObject _uiParent;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private SelectorVariantUI _selectorSlotPrefab;
        [SerializeField] private Transform _slotsParent;

        [SerializeField] private NovelControllerComponent _novelController;

        private readonly List<SelectorVariantUI> _slots = new();
        private IReadOnlyList<SelectorVariant> _variants;


        public void ShowSelector(string title, IReadOnlyList<SelectorVariant> variants)
        {
            ClearUI();
            _variants = variants;
            _title.text = title;

            for (int i = 0; i < variants.Count; i++)
            {
                SelectorVariant variant = variants[i];
                var slot = Instantiate(_selectorSlotPrefab, _slotsParent);
                _slots.Add(slot);
                slot.Init(this, i, variant.Title);
            }

            _uiParent.SetActive(true);
        }

        internal void RegisterClick(int index)
        {
            ClearUI();
            var selectedVariant = _variants[index];
            _variants = null;
            _novelController.SetStoryLine(selectedVariant.Destination, 0);
            _novelController.GoNext();
        }

        private void ClearUI()
        {
            _uiParent.SetActive(false);
            _title.text = string.Empty;

            foreach (var slot in _slots)
            {
                Destroy(slot.gameObject);
            }

            _slots.Clear();
        }
    }
}
