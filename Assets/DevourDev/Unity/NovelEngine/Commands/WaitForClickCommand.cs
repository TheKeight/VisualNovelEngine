using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(WaitForClickCommand))]
    public sealed class WaitForClickCommand : NovelCommand
    {
        public static WaitForClickCommand Create()
        {
            return CreateInstance<WaitForClickCommand>();
        }
    }
}
