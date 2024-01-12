using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Entities.Interface
{
    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(Sound))]
    public sealed class Sound : SoundBase, ISound
    {
        [SerializeField] private AudioClip _sound;


        public override AudioClip Clip => _sound;
    }
}
