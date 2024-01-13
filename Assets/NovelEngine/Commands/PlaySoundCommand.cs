using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(PlaySoundCommand))]
    public sealed class PlaySoundCommand : NovelCommand
    {
        [field: SerializeField] public Sound Sound { get; private set; }


        public static PlaySoundCommand Create(Sound sound)
        {
            var inst = CreateInstance<PlaySoundCommand>();
            inst.Sound = sound;
            return inst;
        }
    }
}
