using System;
using System.Collections.Generic;
using System.Linq;
using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Commands.Variables;
using DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using DevourDev.Utility;
using UnityEngine.Assertions;

namespace DevourDev.Unity.NovelEngine.Builders.BaseBuilder
{
    public readonly struct NovelScriptData
    {
        private readonly StoryLine[] _storyLines;
        private readonly int _startStoryLineIndex;


        public NovelScriptData(StoryLine[] storyLines, int startStoryLineIndex)
        {
            _storyLines = storyLines;
            _startStoryLineIndex = startStoryLineIndex;
        }


        public StoryLine[] StoryLines => _storyLines;
        public int StartStoryLineIndex => _startStoryLineIndex;
    }

    public interface INovelScriptBuilder : IBuilder<NovelScriptData>
    {
    }

    public sealed class NovelScriptBuilder : INovelScriptBuilder
    {
        private sealed class AutoBranchBuilder
        {
            private sealed class BlockBuilder
            {
                private VariableCondition<int> _condition;
                private StoryLine _destination;


                public void SetCondition(VariableCondition<int> condition) => _condition = condition;
                public void SetDestination(StoryLine destination) => _destination = destination;

                public EvaluateVariableConditionBranchCommand<int>.Block Build() => new(_condition, _destination);

                public void Clear()
                {
                    _condition = default;
                    _destination = null;
                }
            }

            private readonly BlockBuilder _blockBuilder = new();
            private readonly List<EvaluateVariableConditionBranchCommand<int>.Block> _blocks = new();


            public void BeginBlock(VariableCondition<int> condition)
            {
                _blockBuilder.SetCondition(condition);
            }

            public void EndBlock(StoryLine destination)
            {
                _blockBuilder.SetDestination(destination);
                _blocks.Add(_blockBuilder.Build());
                _blockBuilder.Clear();
            }

            public EvaluateIntegerVariableConditionBranchCommand Build()
            {
                var cmd = EvaluateIntegerVariableConditionBranchCommand.Create(_blocks);
                return cmd;
            }

            public void Clear()
            {
                _blocks.Clear();
            }
        }

        private sealed class SelectorBuilder
        {
            private sealed class VariantBuilder
            {
                private string _title;
                private StoryLine _destination;


                public void SetTitle(string title) => _title = title;

                public void SetDestination(StoryLine destination) => _destination = destination;

                public SelectorVariant Build()
                {
                    if (_destination is null)
                        throw new System.ArgumentNullException(nameof(_destination));

                    return new(_title, _destination);
                }

                public void Clear()
                {
                    _title = string.Empty;
                    _destination = null;
                }
            }

            private string _title;
            private readonly List<SelectorVariant> _variants = new();
            private readonly VariantBuilder _variantBuilder = new();

            public void SetSelectorTitle(string selectorTitle)
            {
                _title = selectorTitle;
            }

            public void BeginVariant(string variantTitle)
            {
                _variantBuilder.SetTitle(variantTitle);
            }

            public void EndVariant(StoryLine destination)
            {
                _variantBuilder.SetDestination(destination);
                _variants.Add(_variantBuilder.Build());
                _variantBuilder.Clear();
            }

            public ShowSelectorCommand Build()
            {
                return ShowSelectorCommand.Create(_title, _variants);
            }

            public void Clear()
            {
                _title = string.Empty;
                _variants.Clear();
            }
        }


        private readonly Dictionary<string, StoryLine.StoryLineCreationHandle> _storyLineHandles = new();
        private readonly SelectorBuilder _selectorBuilder = new();
        private readonly AutoBranchBuilder _autoBranchBuilder = new();
        private StoryLine.StoryLineCreationHandle _currentStoryLine = null;
        private StoryLine _startStoryLine = null;


        public NovelScriptData Build()
        {
            Assert.IsNotNull(_startStoryLine);

            StoryLine[] storyLines = _storyLineHandles.Values.Select(handle =>
            {
                handle.Finish();
                return handle.StoryLine;
            }).ToArray();

            int startStoryLineIndex = Array.FindIndex(storyLines, sl => sl == _startStoryLine);
            var result = new NovelScriptData(storyLines, startStoryLineIndex);
            return result;
        }

        public void BeginLabel(string labelName)
        {
            EnsureCurrentStoryLineNotExists();
            var esl = GetOrCreateStoryLineHandle(labelName);
            _currentStoryLine = esl;
            _startStoryLine ??= esl.StoryLine;
        }

        public void EndLabel()
        {
            EnsureCurrentStoryLineExists();
            _currentStoryLine = null;
        }

        public void Say(Character speaker, string speech)
        {
            EnsureCurrentStoryLineExists();
            var cmd = SayCommand.Create(speaker, speech);
            AddCommand(cmd);
        }

        public void Show(Character character, float position)
        {
            EnsureCurrentStoryLineExists();
            var cmd = ShowCharacterCommand.Create(character, position, null);
            AddCommand(cmd);
        }

        public void Jump(string destinationLabelName)
        {
            EnsureCurrentStoryLineExists();
            var cmd = JumpToStoryLineCommand.Create(GetStoryLine(destinationLabelName));
            AddCommand(cmd);
        }

        public void BeginSelector(string selectorTitle)
        {
            _selectorBuilder.SetSelectorTitle(selectorTitle);
        }

        public void BeginSelectorVariant(string variantTitle)
        {
            _selectorBuilder.BeginVariant(variantTitle);
        }

        public void EndSelectorVariant(string destinationLabelName)
        {
            _selectorBuilder.EndVariant(GetStoryLine(destinationLabelName));
        }

        public void EndSelector()
        {
            EnsureCurrentStoryLineExists();
            var cmd = _selectorBuilder.Build();
            AddCommand(cmd);
            _selectorBuilder.Clear();
        }

        public void BeginAutoBranch()
        {
            // Design placeholder.
        }

        public void BeginConditionBlock(VariableCondition<int> condition)
        {
            _autoBranchBuilder.BeginBlock(condition);
        }

        public void EndConditionBlock(string destinationLabelName)
        {
            _autoBranchBuilder.EndBlock(GetStoryLine(destinationLabelName));
        }

        public void EndAutoBranch()
        {
            var cmd = _autoBranchBuilder.Build();
            AddCommand(cmd);
            _autoBranchBuilder.Clear();
        }
        
        public void ChangeVariable(Character character, NovelVariable<int> variable, MathOperation operation, int value)
        {
            var cmd = ChangeIntegerNovelVariableCommand.Create(character, variable, operation, value);
            AddCommand(cmd);
        }

        public void AddCommand(NovelCommand cmd)
        {
            _currentStoryLine.AddCommand(cmd);
        }

        public StoryLine GetStoryLine(string labelName) => GetOrCreateStoryLineHandle(labelName).StoryLine;

        private StoryLine.StoryLineCreationHandle GetOrCreateStoryLineHandle(string labelName)
        {
            if (!_storyLineHandles.TryGetValue(labelName, out var value))
            {
                value = StoryLine.CreateWithHandle();
                _storyLineHandles[labelName] = value;
            }

            return value;
        }

        private void EnsureCurrentStoryLineExists()
        {
            Assert.IsNotNull(_currentStoryLine);
        }

        private void EnsureCurrentStoryLineNotExists()
        {
            Assert.IsNull(_currentStoryLine);
        }
    }
}
