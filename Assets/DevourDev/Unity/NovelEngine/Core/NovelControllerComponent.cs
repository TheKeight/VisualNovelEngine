using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using DevourDev.Unity.Utility.Serialization;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Core
{
    [DefaultExecutionOrder(-2000)]
    internal sealed class NovelControllerComponent : MonoBehaviour, INovelController
    {
        [SerializeField] private SerializedInterface<ICommandsManager> _commandsManager;
        [SerializeField] private TypeMap<NovelCommand, bool> _stoppingCommands;
        [SerializeField] private TypeMap<NovelCommand, bool> _blockingCommands;

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
