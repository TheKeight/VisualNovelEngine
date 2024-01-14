using NovelEngine.Tagging;
using UnityEngine;

namespace NovelEngine.HotChests200.NovelScripting
{
    public sealed class NovelTagsManager : MonoBehaviour
    {
        private static NovelTagsManager _instance;

        [SerializeField] private TagSO _blush;
        [SerializeField] private TagSO _fists;
        [SerializeField] private TagSO _happy;
        [SerializeField] private TagSO _idunnoLol;
        [SerializeField] private TagSO _neutral;
        [SerializeField] private TagSO _noodles;
        [SerializeField] private TagSO _sad;
        [SerializeField] private TagSO _shy;
        [SerializeField] private TagSO _smile;
        [SerializeField] private TagSO _thinking;
        [SerializeField] private TagSO _vahui;
        [SerializeField] private TagSO _huh;


        public static TagSO Blush => _instance._blush;
        public static TagSO Fists => _instance._fists;
        public static TagSO Happy => _instance._happy;
        public static TagSO IDunnoLol => _instance._idunnoLol;
        public static TagSO Neutral => _instance._neutral;
        public static TagSO Noodles => _instance._noodles;
        public static TagSO Sad => _instance._sad;
        public static TagSO Shy => _instance._shy;
        public static TagSO Smile => _instance._smile;
        public static TagSO Thinking => _instance._thinking;
        public static TagSO Vahui => _instance._vahui;
        public static TagSO Huh => _instance._huh;


        private void Awake()
        {
            _instance = this;
        }
    }
}
