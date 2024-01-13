using DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces;
using NovelEngine.UX.Variables;

namespace NovelEngine.CommandHandlers.Variables.Interfaces
{
    public abstract class ChangeNovelVariableCommandHandler<TValue, TChangeVariableCommand> : CommandHandlerComponent<TChangeVariableCommand>
        where TChangeVariableCommand : ChangeNovelVariableCommand<TValue>
    {
        [UnityEngine.SerializeField] private NovelVariablesManager _manager;


        public sealed override void Handle(TChangeVariableCommand command)
        {
            _manager.ChangeCharacterVariable(command.Character, command.Variable, command.Operation, command.Value);    
        }
    }
}