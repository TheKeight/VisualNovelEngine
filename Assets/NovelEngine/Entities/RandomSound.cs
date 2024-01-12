using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.Entities
{
    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(RandomSound))]
    public sealed class RandomSound : SoundBase, ISound
    {
        [SerializeField] private AudioClip[] _sounds;


        public override AudioClip Clip => GetRandomSound();

        private AudioClip GetRandomSound()
        {
            var index = UnityEngine.Random.Range(0, _sounds.Length);
            return _sounds[index];
        }
    }
}
