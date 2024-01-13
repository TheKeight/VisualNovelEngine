using UnityEngine;

namespace NovelEngine.Entities.Interface
{
    public abstract class Sound : ScriptableObject, ISound
    {
        public abstract AudioClip Clip { get; }
    }
}
