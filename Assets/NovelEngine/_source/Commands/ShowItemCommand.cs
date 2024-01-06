using UnityEngine;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ShowItemCommand))]
    public sealed class ShowItemCommand : CommandSO, ICommand
    {
        [SerializeField] private ItemSO _item;
        [SerializeField] private ScenePositionSO _position;
        [SerializeField] private AppearanceKeySO _appearanceKey;


        public ItemSO Item => _item;
        public ScenePositionSO Position => _position;
        public AppearanceKeySO AppearanceKey => _appearanceKey;


        public static ShowItemCommand Create(ItemSO item,
            ScenePositionSO scenePosition, AppearanceKeySO appearanceKey)
        {
            var inst = ScriptableObject.CreateInstance<ShowItemCommand>();
            inst._item = item;
            inst._position = scenePosition;
            inst._appearanceKey = appearanceKey;
            return inst;
        }
    }
}
