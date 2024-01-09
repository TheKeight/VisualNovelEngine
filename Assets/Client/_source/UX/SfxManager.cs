using UnityEngine;

namespace VisualNovel.Client.UX
{
    public sealed class SfxManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _sfxSource;


        public void PlaySound(AudioClip clip)
        {
            _sfxSource.PlayOneShot(clip);
        }
    }
}