using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX
{
    public sealed class SfxManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _sfxSource;


        public void PlaySound(SoundBase sound)
        {
            _sfxSource.PlayOneShot(sound.Clip);
        }
    }
}