using DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces;
using NovelEngine.UX.Variables;

namespace NovelEngine.CommandHandlers.Variables.Interfaces
{
    public abstract class EvaluateVariableConditionBranchCommandHandler<TValue, TCommand> : CommandHandlerComponent<TCommand>
        where TCommand : EvaluateVariableConditionBranchCommand<TValue>
    {
        [UnityEngine.SerializeField] private NovelAutoBranchingManager _branchingManager;


        public sealed override void Handle(TCommand command)
        {
            _branchingManager.EvaluateBranch(command.Blocks, command.DefaultDestination);    
        }
    }
}