using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces
{
    public abstract class EvaluateVariableConditionBranchCommand<T> : NovelCommand
    {
        [System.Serializable]
        public struct Block
        {
            public VariableCondition<T> Condition;
            public StoryLine Destination;


            public Block(VariableCondition<T> condition, StoryLine destination)
            {
                Condition = condition;
                Destination = destination;
            }
        }


        [SerializeField] private Block[] _blocks;
        [SerializeField] private StoryLine _defaultDestination;


        public IReadOnlyList<Block> Blocks => _blocks;
        public StoryLine DefaultDestination => _defaultDestination;


        protected void Init(Block[] blocks)
        {
            _blocks = blocks;
        }
    }
}
