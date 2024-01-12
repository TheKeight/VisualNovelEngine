using DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ChangeIntegerNovelVariableCommand))]
    public sealed class ChangeIntegerNovelVariableCommand : ChangeNovelVariableCommand<int>
    {
        public static ChangeIntegerNovelVariableCommand Create(Character character,
            NovelVariable<int> variable, MathOperation operation, int value)
        {
            var inst = CreateInstance<ChangeIntegerNovelVariableCommand>();
            inst.Init(character, variable, operation, value);
            return inst;
        }
    }
}
