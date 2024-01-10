using System;
using System.Collections.Generic;
using System.Linq;
using VisualNovel.Commands;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Scripting.EntityBuilders
{
    public sealed class StoryLineBuilder : IBuilder<StoryLineSO>
    {
        private readonly List<IBuilder<CommandSO>> _commands = new();
        private StoryLineSO _cachedBuild;


        public StoryLineBuilder()
        {
            
        }


        public StoryLineBuilder AddCommand<TCmd>(IBuilder<TCmd> commandBuilder)
            where TCmd : CommandSO
        {
            _commands.Add(commandBuilder);
            return this;
        }

        public StoryLineBuilder AddCommand(CommandSO command)
        {
            return AddCommand(new FromResultBuilder<CommandSO>(command));
        }

        public StoryLineBuilder AddCommands(params IBuilder<CommandSO>[] commandBuilders)
        {
            return AddCommands((IEnumerable<IBuilder<CommandSO>>)commandBuilders);
        }

        public StoryLineBuilder AddCommands(IEnumerable<IBuilder<CommandSO>> commandBuilders)
        {
            _commands.AddRange(commandBuilders);
            return this;
        }

        public StoryLineBuilder AddCommands(params CommandSO[] commands)
        {
            return AddCommands((IEnumerable<CommandSO>)commands);
        }

        public StoryLineBuilder AddCommands(IEnumerable<CommandSO> commands)
        {
            return AddCommands(commands.Select(cmd => new FromResultBuilder<CommandSO>(cmd)));
        }


        private static long _counter;

        public StoryLineSO Build()
        {
            if(++_counter > 200)
            {
                long tmp = _counter;
                _counter = 0;
                throw new InvalidOperationException(tmp.ToString());
            }

            _cachedBuild ??= StoryLineSO.Create(_commands.Select(builder => builder.Build()));
            return _cachedBuild;
        }
    }
}
