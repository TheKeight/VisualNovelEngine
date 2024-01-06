using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ChangeBackGroundMusicCommand))]
    public sealed class ChangeBackGroundMusicCommand : CommandSO, ICommand
    {
        [SerializeField] private AudioPlaylist _playlist;


        public AudioPlaylist Playlist => _playlist;


        public static ChangeBackGroundMusicCommand Create(AudioPlaylist playlist)
        {
            var inst = ScriptableObject.CreateInstance<ChangeBackGroundMusicCommand>();
            inst._playlist = playlist;
            return inst;
        }
    }
}
