using System;
using UnityEngine;
using VisualNovel.Commands;
using VisualNovel.CommandSystem;

namespace VisualNovel.Client.CommandExecutors
{
    public abstract class CommandExecutorComponent : MonoBehaviour, ICommandExecutor
    {
        public abstract System.Type CommandType { get; }
        public abstract void Execute(ICommand command);
    }

    public abstract class CommandExecutorComponent<TCmd> : CommandExecutorComponent, ICommandExecutor<TCmd>
        where TCmd : CommandSO
    {
        public sealed override Type CommandType => typeof(TCmd);

        public sealed override void Execute(ICommand command)
        {
            Execute((TCmd)command);
        }

        public abstract void Execute(TCmd command);
    }
}