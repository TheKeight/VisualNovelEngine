using NovelEngine.Commands;
using UnityEngine;
using NovelEngine.CommandHandlers.UX;

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