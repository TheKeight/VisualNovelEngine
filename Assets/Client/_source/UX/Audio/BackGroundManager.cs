using NovelEngine.Entities.Interface;
using NovelEngine.Utility;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX
{
    public sealed class BackGroundManager : MonoBehaviour
    {
        [SerializeField] private float _zPos = 0;
        private BackGround _currentBG;


        public void ChangeBackGroundImage(BackGround bg)
        {
            if (_currentBG != null)
            {
                Destroy(_currentBG.gameObject);
            }

            var cam = Camera.main;
            var pos = cam.transform.position;
            pos.z = _zPos;
            _currentBG = Instantiate(bg, pos, Quaternion.identity);
        }
    }
}