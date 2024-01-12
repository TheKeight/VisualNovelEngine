using DevourDev.Unity.NovelEngine.Commands;
using NovelEngine.CommandHandlers.UX.Selection;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class ShowSelectorCommandHandler : CommandHandlerComponent<ShowSelectorCommand>
    {
        [SerializeField] private SelectorUI _selectionManager;


        public override void Handle(ShowSelectorCommand command)
        {
            _selectionManager.ShowSelector(command.Title, command.Variants);
        }
    }
}