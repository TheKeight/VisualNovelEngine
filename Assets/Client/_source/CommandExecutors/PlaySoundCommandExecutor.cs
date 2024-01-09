using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class PlaySoundCommandExecutor : CommandExecutorComponent<PlaySoundCommand>
    {
        [SerializeField] private SfxManager _sfxManager;


        public override void Execute(PlaySoundCommand command)
        {
            _sfxManager.PlaySound(command.Clip);
        }
    }
}