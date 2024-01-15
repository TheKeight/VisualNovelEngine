using DevourDev.Unity.NovelEngine.Commands.Variables;
using NovelEngine.UX.Variables;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public sealed class EvaluateIntegerVariableConditionBranchCommandHandler : CommandHandlerComponent<EvaluateIntegerVariableConditionBranchCommand>
    {
        [SerializeField] private NovelAutoBranchingManager _branchingManager;


        public override void Handle(EvaluateIntegerVariableConditionBranchCommand command)
        {
            _branchingManager.EvaluateBranch(command.Blocks, command.DefaultDestination);
        }
    }
}