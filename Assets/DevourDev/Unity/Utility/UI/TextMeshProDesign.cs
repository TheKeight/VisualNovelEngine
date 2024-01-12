using TMPro;
using UnityEngine;

namespace DevourDev.Unity.Utility.UI
{
    [System.Serializable]
    public struct TextMeshProDesign
    {
        [SerializeField] private Color _textColor;
        [SerializeField] private Color _outlineColor;


        public TextMeshProDesign(Color textColor, Color outlineColor)
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