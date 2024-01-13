using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Entities.Interface
{
    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(SimpleSound))]
    public sealed class SimpleSound : Sound, ISound
    {
        [SerializeField] private AudioClip _sound;


        public override AudioClip Clip => _sound;
    }
}
