using System;
using System.Collections.Generic;
using VisualNovel.CommandSystem;

namespace VisualNovel.Engine
{
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


}
