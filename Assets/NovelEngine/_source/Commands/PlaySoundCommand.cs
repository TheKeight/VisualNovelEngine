using UnityEngine;
using VisualNovel.CommandSystem;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(PlaySoundCommand))]
    public sealed class PlaySoundCommand : CommandSO, ICommand
    {
        [SerializeField] private AudioClip _clip;


        public AudioClip Clip => _clip;


        public static PlaySoundCommand Create(AudioClip clip)
        {
            var inst = ScriptableObject.CreateInstance<PlaySoundCommand>();
            inst._clip = clip;
            return inst;
        }
    }
}
