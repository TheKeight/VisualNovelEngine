using UnityEngine;
using VisualNovel.Commands;
using VisualNovel.CommandSystem;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Engine
{
    [DefaultExecutionOrder(-2000)]
    internal sealed class NovelControllerComponent : MonoBehaviour, INovelController
    {
        [SerializeField] private SerializedInterface<ICommandsManager> _commandsManager;
        [SerializeField] private TypeMap<CommandSO, bool> _stoppingCommands;
        [SerializeField] private TypeMap<CommandSO, bool> _blockingCommands;

        private INovelController _controller;


        public bool CanGoNext => _controller.CanGoNext;


        private void Awake()
        {
            _controller = new NovelController(_commandsManager.Item, _stoppingCommands, _blockingCommands);
        }

        public void GoNext()
        {
            _controller.GoNext();
        }

        public void SetStoryLine(IStoryLine storyLine, int startIndex)
        {
            _controller.SetStoryLine(storyLine, startIndex);
        }
    }
}
