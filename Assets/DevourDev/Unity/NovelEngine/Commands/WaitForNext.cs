using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(WaitForNext))]
    public sealed class WaitForNext : NovelCommand
    {
        public static WaitForNext Create()
        {
            return CreateInstance<WaitForNext>();
        }
    }
}
