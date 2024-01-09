using UnityEngine;

namespace VisualNovel.Entities
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "Screen Position")]
    public sealed class ScenePositionSO : ScriptableObject
    {
        [SerializeField, Range(0f, 1f)] private float _positionX;
        [SerializeField, Range(0f, 1f)] private float _positionY;


        public float PositionX => _positionX;
        public float PositionY => _positionY;
    }
}