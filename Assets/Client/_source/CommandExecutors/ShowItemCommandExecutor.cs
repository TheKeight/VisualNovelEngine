using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ShowItemCommandExecutor : CommandExecutorComponent<ShowItemCommand>
    {
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;


        public override void Execute(ShowItemCommand command)
        {
            _itemsOnSceneManager.Show(command.Item, command.AppearanceKey, command.Position);
        }
    }
}