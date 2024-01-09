using UnityEngine;
using VisualNovel.Client.UX;
using VisualNovel.Commands;

namespace VisualNovel.Client.CommandExecutors
{
    public sealed class ChangeBackGroundImageCommandExecutor : CommandExecutorComponent<ChangeBackGroundImageCommand>
    {
        [SerializeField] private BackGroundManager _backGroundManager;


        public override void Execute(ChangeBackGroundImageCommand command)
        {
            _backGroundManager.ChangeBackGroundImage(command.Sprite);
        }
    }
}