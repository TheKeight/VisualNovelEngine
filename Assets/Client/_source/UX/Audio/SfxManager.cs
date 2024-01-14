using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.UX.Audio
{
    public sealed class SfxManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _sfxSource;


        public void PlaySound(Sound sound)
        {
            if (sound == null)
                return;

            _sfxSource.PlayOneShot(sound.Clip);
        }
    }
}