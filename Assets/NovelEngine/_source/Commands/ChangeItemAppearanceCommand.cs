using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{

    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ChangeItemAppearanceCommand))]
    public sealed class ChangeItemAppearanceCommand : CommandSO, ICommand
    {
        [SerializeField] private ItemSO _item;
        [SerializeField] private AppearanceKeySO _appearanceKey;


        public ItemSO Item => _item;
        public AppearanceKeySO AppearanceKey => _appearanceKey;


        public static ChangeItemAppearanceCommand Create(ItemSO item,
            AppearanceKeySO appearanceKey)
        {
            var inst = ScriptableObject.CreateInstance<ChangeItemAppearanceCommand>();
            inst._item = item;
            inst._appearanceKey = appearanceKey;
            return inst;
        }
    }
}
