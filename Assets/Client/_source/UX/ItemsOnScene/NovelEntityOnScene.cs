﻿using NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX
{
    public abstract class NovelEntityOnScene<TEntityReference> : MonoBehaviour
    {
        public abstract TEntityReference Reference { get; }
        public abstract AppearanceKey AppearanceKey { get; set; }


        public abstract void Init(TEntityReference reference, AppearanceKey appearanceKey);
    }
}