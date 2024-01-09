using UnityEngine;
using VisualNovel.Client.CommandExecutors;
using VisualNovel.CommandSystem;
using VisualNovel.Utility;

namespace VisualNovel.Client.Utility
{
    public sealed class CommandExecutorComponentsRegistrar : MonoBehaviour
    {
        [SerializeField] private SerializedInterface<ICommandsManager> _commandsManager;


        private void Awake()
        {
            var manager = _commandsManager.Item;

            var executors = FindObjectsOfType<CommandExecutorComponent>(false);

            foreach (var executor in executors)
            {
                manager.RegisterCommandExecutor(executor.CommandType, executor);
            }
        }
    }
}