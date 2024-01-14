using System.Collections.Generic;
using NovelEngine.Entities;
using NovelEngine.Tagging;
using UnityEngine;

namespace NovelEngine.UX.ItemsOnScene
{
    public abstract class NovelEntityOnScene<TEntityReference> : MonoBehaviour
    {
        public abstract TEntityReference Reference { get; }
        public abstract AppearanceKey AppearanceKey { get; }
        public abstract float Position { get; }


        public abstract void Init(TEntityReference reference,
            PositionManager positionManager, float position,
            float moveTime, AppearanceKey appearanceKey);

        public abstract void Init(TEntityReference reference,
            PositionManager positionManager, float position,
            float moveTime, QueryMode queryMode, IReadOnlyList<TagSO> tags,
            IReadOnlyList<TagSO> blackListTags);


        public abstract void ChangeAppearance(AppearanceKey appearanceKey);
        public abstract void ChangeAppearance(QueryMode mode, IReadOnlyList<TagSO> tags, IReadOnlyList<TagSO> blackListTags);

        public abstract void ChangePosition(float targetPosition, float time);
    }
}