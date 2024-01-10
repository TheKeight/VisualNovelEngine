using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    public abstract class NovelEntityOnScene<TEntityReference> : MonoBehaviour
    {
        public abstract TEntityReference Reference { get; }
        public abstract AppearanceKeySO AppearanceKey { get; set; }


        public abstract void Init(TEntityReference reference, AppearanceKeySO appearanceKey);
    }
}