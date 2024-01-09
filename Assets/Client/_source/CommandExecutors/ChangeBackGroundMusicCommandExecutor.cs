using UnityEngine;
using VisualNovel.Client.UX;
using VisualNovel.Commands;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ChangeBackGroundMusicCommandExecutor : CommandExecutorComponent<ChangeBackGroundMusicCommand>
    {
        [SerializeField] private BgmManager _bgmManager;
        [SerializeField] private bool _shuffle = true;


        public override void Execute(ChangeBackGroundMusicCommand command)
        {
            _bgmManager.ChangePlaylist(command.Playlist, _shuffle);
            _bgmManager.Play();
        }
    }
}