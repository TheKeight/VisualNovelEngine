using DevourDev.Unity.Utility.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NovelEngine.CommandHandlers.UX.Selection
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

        public void Init(SelectorUI selector, int index, string title, TextMeshProDesign titleTextDesign)
        {
            Init(selector, index, title);
            titleTextDesign.Apply(_title);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            _selector.RegisterClick(_index);
        }
    }
}
