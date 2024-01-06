using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisualNovel.Commands;

namespace VisualNovel.Entities
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Entities + "Audio Playlist")]
    public sealed class AudioPlaylist : ScriptableObject
    {
        [SerializeField] private AudioClip[] _clips;


        public IReadOnlyList<AudioClip> Clips => _clips;


        public static AudioPlaylist Create(IEnumerable<AudioClip> clips)
        {
            var inst = ScriptableObject.CreateInstance<AudioPlaylist>();
            inst._clips = clips.ToArray();
            return inst;
        }
    }
}