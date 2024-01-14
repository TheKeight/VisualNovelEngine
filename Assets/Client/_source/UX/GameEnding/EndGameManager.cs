using TMPro;
using UnityEngine;

namespace NovelEngine.UX.GameEnding
{
    public sealed class EndGameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _uiObject;
        [SerializeField] private GameObject[] _uiToDisableObject;
        [SerializeField] private TMP_Text _text;


        public void EndGame(string message)
        {
            _text.text = message;
            _uiObject.SetActive(true);

            foreach (var item in _uiToDisableObject)
            {
                item.SetActive(false);
            }
        }
    }
}
