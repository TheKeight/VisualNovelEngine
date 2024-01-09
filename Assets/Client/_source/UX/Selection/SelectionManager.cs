using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using VisualNovel.Commands;
using VisualNovel.Utility;

namespace VisualNovel.Client.UX.Selection
{
    //TODO: придумать логику показа\скрытия элементов, чтобы можно было скрыть весь
    // интерфейс (оставить только фон, персов и предметы).
    internal sealed class SelectorVariantUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _title;

        private SelectorUI _selector;
        private int _index;


        public void Init(SelectorUI selector, int index, string title)
        {
            _selector = selector;
            _index = index;
            _title.text = title;
        }

        public void Init(SelectorUI selector, int index, string title, TextDesign titleTextDesign)
        {
            Init(selector, index, title);
            titleTextDesign.Apply(_title);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            _selector.RegisterClick(_index);
        }
    }

    internal sealed class SelectorUI : MonoBehaviour
    {
        [SerializeField] private GameObject _uiParent;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private SelectorVariantUI _selectorSlotPrefab;
        [SerializeField] private Transform _slotsParent;

        private readonly List<SelectorVariantUI> _slots = new();
        private IReadOnlyList<ISelectorVariant> _variants;


        public void ShowSelector(string title, IReadOnlyList<ISelectorVariant> variants)
        {
            Clear();
            _variants = variants;
            _title.text = title;

            for (int i = 0; i < variants.Count; i++)
            {
                ISelectorVariant variant = variants[i];
                var slot = Instantiate(_selectorSlotPrefab, _slotsParent);
                _slots.Add(slot);
                slot.Init(this, i, variant.Title);
            }


        }

        internal void RegisterClick(int index)
        {
            Clear();
            _variants = null;
        }

        private void Clear()
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

    public sealed class SelectionManager : MonoBehaviour
    {
        [SerializeField] private SelectorUI _selectorUI;

       
    }
}
