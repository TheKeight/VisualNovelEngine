using VisualNovel.Commands;
using UnityEngine;
using VisualNovel.Client.UX.Selection;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ShowSelectorCommandExecutor : CommandExecutorComponent<ShowSelectorCommand>
    {
        [SerializeField] private SelectorUI _selectionManager;


        public override void Execute(ShowSelectorCommand command)
        {
            _selectionManager.ShowSelector(command.Title, command.Variants);
        }
    }
}