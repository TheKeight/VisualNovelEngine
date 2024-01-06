using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading.Tasks;
using UnityEngine;
using VisualNovel.CommandSystem;

namespace VisualNovel.Engine
{
    public sealed class MyNovelEngine : MonoBehaviour, INovelEngine
    {
        private readonly List<ICommand> _commandsHistory = new();
        private ICommandsManager _commandsManager; // !!!!!!!


        public int GetHistoryCommands(int limit, in ICollection<Type> filter, IList<ICommand> buffer)
        {
            int left = limit;
            for (int i = _commandsHistory.Count - 1; left > 0 && i >= 0; i--)
            {
                var cmd = _commandsHistory[i];

                if (!filter.Contains(cmd.GetType()))
                    continue;

                buffer.Add(cmd);
                --left;
            }

            return limit - left;
        }

        public void ExecuteCommand(ICommand command)
        {
            _commandsManager.Execute(command);
        }
    }

    public interface INovelEngine
    {
        /// <param name="filter">Types of commands to fetch.</param>
        /// <param name="buffer">Buffer to fill (add) with commands.
        /// Commands will be added in reverse order (first added command
        /// most likely will be last executed command).</param>
        /// <returns></returns>
        int GetHistoryCommands(int limit, in ICollection<Type> filter, IList<ICommand> buffer);

        void ExecuteCommand(ICommand command);
        
    }
    public static class NovelEngine
    {
        private static INovelEngine _impl;
         
    }
}
