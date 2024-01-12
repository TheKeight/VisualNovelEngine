using System;
using System.Collections.Generic;
using System.Linq;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Entities
{
    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(StoryLine))]
    public sealed class StoryLine : NovelEntity, IStoryLine
    {
        public sealed class StoryLineCreationHandle : IDisposable
        {
            private readonly StoryLine _storyLine;
            private List<NovelCommand> _commandList;
            private bool _disposed;


            internal StoryLineCreationHandle(StoryLine storyLine)
            {
                _storyLine = storyLine;
                _commandList = new();
                _disposed = false;
            }


            public StoryLine StoryLine => _storyLine;


            public void AddCommand(NovelCommand command)
            {
                ThrowIfDisposed();
                _commandList.Add(command);
            }

            public void Finish()
            {
                _storyLine._commands = _commandList.ToArray();
                ((IDisposable)this).Dispose();
            }

            void IDisposable.Dispose()
            {
                _disposed = true;
                _commandList = null;
            }

            private void ThrowIfDisposed()
            {
                if (_disposed)
                    throw new ObjectDisposedException(nameof(StoryLineCreationHandle));
            }
        }


        [SerializeField] private NovelCommand[] _commands;


        public IReadOnlyList<NovelCommand> Commands => _commands;


        public static StoryLine Create(IEnumerable<NovelCommand> commands)
        {
            var inst = CreateInstance<StoryLine>();
            inst._commands = commands.ToArray();
            return inst;
        }

        public static StoryLineCreationHandle CreateWithHandle()
        {
            var inst = CreateInstance<StoryLine>();
            return new StoryLineCreationHandle(inst);
        }
    }

}
