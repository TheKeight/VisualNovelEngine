using System.Collections.Generic;
using System.Linq;
using DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands.Variables
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(EvaluateIntegerVariableConditionBranchCommand))]
    public sealed class EvaluateIntegerVariableConditionBranchCommand : EvaluateVariableConditionBranchCommand<int>
    {
        public static EvaluateIntegerVariableConditionBranchCommand Create(IEnumerable<Block> blocks)
        {
            var inst = CreateInstance<EvaluateIntegerVariableConditionBranchCommand>();
            inst.Init(blocks.ToArray());
            return inst;
        }
    }
}
