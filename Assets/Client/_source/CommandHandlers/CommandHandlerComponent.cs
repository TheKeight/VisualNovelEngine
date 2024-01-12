using System;
using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using UnityEngine;

namespace NovelEngine.CommandHandlers
{
    public abstract class CommandHandlerComponent : MonoBehaviour, ICommandHandler
    {
        public abstract System.Type CommandType { get; }
        public abstract void Handle(ICommand command);
    }

    public abstract class CommandHandlerComponent<TCmd> : CommandHandlerComponent, ICommandHandler<TCmd>
        where TCmd : NovelCommand
    {
        public sealed override Type CommandType => typeof(TCmd);

        public sealed override void Handle(ICommand command)
        {
            Handle((TCmd)command);
        }

        public abstract void Handle(TCmd command);
    }
}