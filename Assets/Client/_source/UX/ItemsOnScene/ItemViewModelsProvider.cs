using UnityEngine;
using VisualNovel.Client.Utility;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    [CreateAssetMenu(menuName = "Visual Novel/Client/ItemVM Provider")]
    public sealed class ItemViewModelsProvider : GameObjectsProviderSO<ItemSO, ItemOnScene>
    {
    }
}