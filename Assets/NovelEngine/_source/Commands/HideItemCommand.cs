using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(HideItemCommand))]
    public sealed class HideItemCommand : CommandSO, ICommand
    {
        [SerializeField] private ItemSO _item;


        public ItemSO Item => _item;


        public static HideItemCommand Create(ItemSO item)
        {
            var inst = ScriptableObject.CreateInstance<HideItemCommand>();
            inst._item = item;
            return inst;
        }
    }
}
