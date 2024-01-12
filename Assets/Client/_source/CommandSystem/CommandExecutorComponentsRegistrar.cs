using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.Utility.Serialization;
using NovelEngine.CommandHandlers;
using UnityEngine;

namespace NovelEngine.CommandSystem
{
    public sealed class CommandExecutorComponentsRegistrar : MonoBehaviour
    {
        [SerializeField] private SerializedInterface<ICommandsManager> _commandsManager;


        private void Awake()
        {
            var manager = _commandsManager.Item;

            var executors = FindObjectsOfType<CommandHandlerComponent>(false);

            foreach (var executor in executors)
            {
                manager.RegisterHandler(executor.CommandType, executor);
            }
        }
    }
}