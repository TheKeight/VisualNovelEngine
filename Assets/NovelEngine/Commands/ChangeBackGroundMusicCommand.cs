using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ChangeBackGroundMusicCommand))]
    public sealed class ChangeBackGroundMusicCommand : NovelCommand
    {
        [SerializeField] private AudioPlayList _music;


        public AudioPlayList PlayList => _music;


        public static ChangeBackGroundMusicCommand Create(AudioPlayList music)
        {
            var inst = CreateInstance<ChangeBackGroundMusicCommand>();
            inst._music = music;
            return inst;
        }
    }


}
