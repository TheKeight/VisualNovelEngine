using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class HideItemCommandExecutor : CommandExecutorComponent<HideItemCommand>
    {
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;


        public override void Execute(HideItemCommand command)
        {
            _itemsOnSceneManager.Hide(command.Item);
        }
    }
}