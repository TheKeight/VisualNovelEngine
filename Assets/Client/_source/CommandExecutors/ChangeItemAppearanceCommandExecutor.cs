using UnityEngine;
using VisualNovel.Client.UX;
using VisualNovel.Commands;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ChangeItemAppearanceCommandExecutor : CommandExecutorComponent<ChangeItemAppearanceCommand>
    {
        [SerializeField] private ItemsOnSceneManager _itemsOnSceneManager;


        public override void Execute(ChangeItemAppearanceCommand command)
        {
            _itemsOnSceneManager.ChangeAppearance(command.Item, command.AppearanceKey);
        }
    }
}