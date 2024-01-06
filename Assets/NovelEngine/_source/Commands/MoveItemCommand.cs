using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(MoveItemCommand))]
    public sealed class MoveItemCommand : CommandSO, ICommand
    {
        [SerializeField] private ItemSO _item;
        [SerializeField] private ScenePositionSO _position;


        public ItemSO Item => _item;
        public ScenePositionSO Position => _position;


        public static MoveItemCommand Create(ItemSO item, ScenePositionSO position)
        {
            var inst = CreateInstance<MoveItemCommand>();
            inst._item = item;
            inst._position = position;
            return inst;
        }
    }
}
