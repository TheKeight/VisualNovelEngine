using UnityEngine;

namespace VisualNovel.Engine
{
    public sealed class NovelModesManager : MonoBehaviour
    {
        [SerializeField] private NovelController _novelController;
        [SerializeField] private NovelPlayMode _initialMode = NovelPlayMode.Normal;


        private NovelPlayMode _mode;


        public NovelPlayMode Mode { get => _mode; set => ChangeMode(value); }


        private void ChangeMode(NovelPlayMode value)
        {
            if (_mode == value)
                return;

            _mode = value;
        }
    }
}
