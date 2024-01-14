using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NovelEngine.Utility
{
    public sealed class UnityMessageBoxOkX : MonoBehaviour
    {
        [SerializeField] private TMP_Text _headText;
        [SerializeField] private TMP_Text _bodyText;
        [SerializeField] private Button _ok;
        [SerializeField] private Button _x;


        private void Awake()
        {
            _ok.onClick.AddListener(() => Destroy(gameObject));
            _x.onClick.AddListener(() => Destroy(gameObject));
        }

        public void Init(string headMsg, string bodyMsg, System.Action okCallback, System.Action xCallback)
        {
            _headText.text = headMsg;
            _bodyText.text = bodyMsg;
            _ok.onClick.AddListener(() => okCallback?.Invoke());
            _x.onClick.AddListener(() => xCallback?.Invoke());
        }
    }
}