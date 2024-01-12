using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.Entities
{
    public sealed class BoundingBackGround : BackGround
    {
        [SerializeField] private Transform _itemToScale;
        [SerializeField] private Transform _min;
        [SerializeField] private Transform _max;


        public override void Encapsulate(Vector2 min, Vector2 max)
        {
            Vector2 thisMin = _min.position;
            Vector2 thisMax = _max.position;

            float width = thisMax.x - thisMin.x;
            float height = thisMax.y - thisMin.y;

            float targetWidth = max.x - min.x;
            float targetHeight = max.y - min.y;

            float widthRatio = targetWidth / width;
            float heightRatio = targetHeight / height;

            float minRatio = Mathf.Min(widthRatio, heightRatio);

            if (Mathf.Approximately(minRatio, 1f))
                return;

            _itemToScale.localScale = new Vector3(minRatio, minRatio, 1f);
        }


        private bool Approximately(Vector2 a, Vector2 b)
        {
            return Mathf.Approximately(a.x, b.x)
                && Mathf.Approximately(a.y, b.y);
        }
    }
}
