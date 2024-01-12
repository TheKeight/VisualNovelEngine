using UnityEngine;
using NovelEngine.CommandHandlers.UX;
using NovelEngine.Commands;

namespace NovelEngine.CommandHandlers
{
    public sealed class ChangeBackGroundImageCommandHandler : CommandHandlerComponent<ChangeBackGroundCommand>
    {
        [SerializeField] private BackGroundManager _backGroundManager;


        public override void Handle(ChangeBackGroundCommand command)
        {
            _backGroundManager.ChangeBackGroundImage(command.BackGround);
        }
    }
}