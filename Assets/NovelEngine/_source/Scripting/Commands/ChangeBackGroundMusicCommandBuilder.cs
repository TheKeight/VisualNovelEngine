using System.Collections.Generic;
using UnityEngine;
using VisualNovel.Commands;

namespace VisualNovel.Scripting.Commands
{
    public sealed class ChangeBackGroundMusicCommandBuilder : CommandBuilder<ChangeBackGroundMusicCommand>
    {
        private readonly List<AudioClip> _clips = new();


        public void AddMusic(AudioClip clip) => _clips.Add(clip);
        public void AddMusic(IEnumerable<AudioClip> clip) => _clips.AddRange(clip);


        protected override ChangeBackGroundMusicCommand BuildConcrete()
        {
            return ChangeBackGroundMusicCommand.Create(Entities.AudioPlaylist.Create(_clips));
        }
    }
}
