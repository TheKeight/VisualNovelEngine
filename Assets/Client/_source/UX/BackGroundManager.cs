using UnityEngine;

namespace VisualNovel.Client.UX
{
    public sealed class BackGroundManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backGroundSpriteRenderer;


        public void ChangeBackGroundImage(Sprite sprite)
        {
            _backGroundSpriteRenderer.sprite = sprite;
        }
    }
}