using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class MoveItemCommandExecutor : CommandExecutorComponent<MoveItemCommand>
    {
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;


        public override void Execute(MoveItemCommand command)
        {
            _itemsOnSceneManager.ChangePosition(command.Item, command.Position);
        }
    }
}