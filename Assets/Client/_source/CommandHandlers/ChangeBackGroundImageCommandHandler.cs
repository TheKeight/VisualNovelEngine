using NovelEngine.Commands;
using NovelEngine.UX.Audio;
using UnityEngine;

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