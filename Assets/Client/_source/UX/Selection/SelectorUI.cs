using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VisualNovel.Commands;
using VisualNovel.Engine;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX.Selection
{
    internal sealed class SelectorUI : MonoBehaviour
    {
        private struct StoryLine : IStoryLine
        {
            public IReadOnlyList<CommandSO> Commands { get; set; }
        }


        [SerializeField] private GameObject _uiParent;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private SelectorVariantUI _selectorSlotPrefab;
        [SerializeField] private Transform _slotsParent;

        [SerializeField] private NovelControllerComponent _novelController;

        private readonly List<SelectorVariantUI> _slots = new();
        private IReadOnlyList<ISelectorVariant> _variants;


        public void ShowSelector(string title, IReadOnlyList<ISelectorVariant> variants)
        {
            ClearUI();
            _variants = variants;
            _title.text = title;

            for (int i = 0; i < variants.Count; i++)
            {
                ISelectorVariant variant = variants[i];
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
            _novelController.SetStoryLine(new StoryLine() { Commands = selectedVariant.Commands }, 0);
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
