using System;
using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Entities
{
    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(AudioPlayList))]
    public sealed class AudioPlayList : ScriptableObject
    {
        [SerializeField] private AudioClip[] _clips;


        public IReadOnlyList<AudioClip> Clips => _clips;
    }
}
