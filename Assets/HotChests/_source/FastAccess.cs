using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.HotChests
{
    [DefaultExecutionOrder(-10000)]
    public sealed class FastAccess : MonoBehaviour
    {
        private static FastAccess _instance;

        [SerializeField] private CharacterSO _mc;
        [SerializeField] private CharacterSO _sonya;
        [SerializeField] private ItemSO _treasureMap;
        [SerializeField] private Sprite _mcHomeBG;
        [SerializeField] private Sprite _outdoorsBG;
        [SerializeField] private AudioPlaylist _routinePlaylist;
        [SerializeField] private AudioPlaylist _depressionPlaylist;
        [SerializeField] private AudioPlaylist _happyPlaylist;
        [SerializeField] private ScenePositionSO _leftPosition;
        [SerializeField] private ScenePositionSO _centerPosition;
        [SerializeField] private ScenePositionSO _rightPosition;


        public static CharacterSO MC => _instance._mc;
        public static CharacterSO Sonya => _instance._sonya;

        public static ItemSO TreasureMap => _instance._treasureMap;

        public static Sprite McHomeBG => _instance._mcHomeBG;
        public static Sprite OutdoorsBG => _instance._outdoorsBG; 

        public static AudioPlaylist RoutinePlaylist => _instance._routinePlaylist;
        public static AudioPlaylist DepressionPlaylist => _instance._depressionPlaylist;
        public static AudioPlaylist HappyPlaylist => _instance._happyPlaylist;

        public static ScenePositionSO LeftPosition => _instance._leftPosition;
        public static ScenePositionSO CenterPosition => _instance._centerPosition;
        public static ScenePositionSO RightPosition => _instance._rightPosition;


        private void Awake()
        {
            _instance = this;
        }
    }
}
