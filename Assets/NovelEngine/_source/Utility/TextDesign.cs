using TMPro;
using UnityEngine;

namespace VisualNovel.Utility
{
    [System.Serializable]
    public struct TextDesign
    {
        [SerializeField] private Color _textColor;
        [SerializeField] private Color _outlineColor;


        public TextDesign(Color textColor, Color outlineColor)
        {
            _textColor = textColor;
            _outlineColor = outlineColor;
        }


        public readonly void Apply(TMP_Text tmpText)
        {
            tmpText.color = _textColor;
            tmpText.outlineColor = _outlineColor;
        }
    }
}