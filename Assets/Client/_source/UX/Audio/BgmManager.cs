using System.Collections.Generic;
using NovelEngine.Entities;
using NovelEngine.Utility;
using UnityEngine;
using UnityEngine.Assertions;

namespace NovelEngine.UX.Audio
{
    public sealed class BgmManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgmSource;

        private AudioPlayList _playlist;
        private List<AudioClip> _clips = new();
        private int _playlistIndex = 0;


        private void Update()
        {
            ProcessPlaylist();
        }

        public void ChangePlaylist(AudioPlayList playlist, bool shuffle)
        {
            _playlist = playlist;
            _playlistIndex = 0;
            _clips.Clear();

            if (playlist == null)
            {
                Stop();
                return;
            }

            _clips.AddRange(playlist.Clips);

            if (shuffle)
            {
                RandomHelpers.Shuffle(_clips);
            }
        }

        public void Stop()
        {
            _bgmSource.Stop();
        }

        public void Play()
        {
            _bgmSource.clip = _clips[_playlistIndex];
            _bgmSource.Play();
        }

        public void Pause()
        {
            _bgmSource.Pause();
        }

        public void UnPause()
        {
            _bgmSource.UnPause();
        }

        private void ProcessPlaylist()
        {
            if (_clips.Count == 0
                || !_bgmSource.isPlaying
                || _bgmSource.clip == null)
                return;

            if (Mathf.Approximately(_bgmSource.clip.length, _bgmSource.time))
            {
                NextClip();
            }
        }

        private void NextClip()
        {
            Assert.IsTrue(_clips.Count > 0);

            ++_playlistIndex;

            if (_playlistIndex >= _clips.Count)
                _playlistIndex = 0;

            Play();
        }
    }
}