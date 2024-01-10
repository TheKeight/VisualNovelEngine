using TMPro;
using UnityEngine;

namespace DevourDev.Unity.Utility.UI
{
    [System.Serializable]
    public struct TextMeshProTextDesign
    {
        [SerializeField] private Color _textColor;
        [SerializeField] private Color _outlineColor;


        public TextMeshProTextDesign(Color textColor, Color outlineColor)
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