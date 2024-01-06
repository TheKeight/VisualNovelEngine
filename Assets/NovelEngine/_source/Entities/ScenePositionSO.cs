using UnityEngine;
using VisualNovel.Commands;

namespace VisualNovel.Entities
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "Screen Position")]
    public sealed class ScenePositionSO : ScriptableObject
    {
        [SerializeField, Range(0f, 1f)] private float _positionX;
        [SerializeField, Range(0f, 1f)] private float _positionY;
    }
}