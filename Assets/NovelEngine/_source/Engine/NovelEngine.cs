using System;
using System.Collections.Generic;
using VisualNovel.CommandSystem;

namespace VisualNovel.Engine
{
    public sealed class NovelEngine : INovelEngine
    {
        private readonly List<ICommand> _commandsHistory = new();
        private readonly ICommandsManager _commandsManager;


        public NovelEngine(ICommandsManager commandsManager)
        {
            _commandsManager = commandsManager;
        }


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
            _commandsHistory.Add(command);
            _commandsManager.Execute(command);
        }
    }
}
