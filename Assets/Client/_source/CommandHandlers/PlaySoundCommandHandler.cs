using NovelEngine.Commands;
using NovelEngine.UX.Audio;
using UnityEngine;

namespace NovelEngine.CommandHandlers.CommandExecutors
{
    public sealed class PlaySoundCommandHandler : CommandHandlerComponent<PlaySoundCommand>
    {
        [SerializeField] private SfxManager _sfxManager;


        public override void Handle(PlaySoundCommand command)
        {
            _sfxManager.PlaySound(command.Sound);
        }
    }
}