using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX
{
    public sealed class BackGroundManager : MonoBehaviour
    {
        [SerializeField] private float _zPos;
        private BackGround _currentBG;


        //TODO: check cam.ViewportToWorldPoint (for z)
        public void ChangeBackGroundImage(BackGround bg)
        {
            if(_currentBG != null)
            {
                Destroy(_currentBG.gameObject);
            }

            var cam = Camera.main;
            var pos = cam.transform.position;
            pos.z = _zPos;
            _currentBG = Instantiate(bg, pos, Quaternion.identity);
            _currentBG.Encapsulate(cam.ViewportToWorldPoint(Vector3.zero), cam.ViewportToWorldPoint(Vector3.one));
        }
    }
}