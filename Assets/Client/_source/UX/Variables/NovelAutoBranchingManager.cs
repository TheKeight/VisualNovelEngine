using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces;
using DevourDev.Unity.NovelEngine.Core;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.UX.Variables
{
    public sealed class NovelAutoBranchingManager : MonoBehaviour
    {
        [SerializeField] private NovelControllerComponent _controller;
        [SerializeField] private NovelVariablesManager _variablesManager;


        public void EvaluateBranch<T>(IEnumerable<EvaluateVariableConditionBranchCommand<T>.Block> blocks,
            StoryLine defaultDestination)
        {
            foreach (var block in blocks)
            {
                if (CheckCondition(block.Condition))
                {
                    Jump(block.Destination);
                    return;
                }
            }

            Jump(defaultDestination);
        }

        private bool CheckCondition<T>(VariableCondition<T> condition)
        {
            T value = _variablesManager.GetCharacterVariableValue(condition.Character, condition.Variable);
            return NovelVariablesHelpers.SolveMathEquation(condition.Variable, value, condition.Equation, condition.Value);
        }

        private void Jump(StoryLine destination)
        {
            _controller.SetStoryLine(destination, 0);
        }
    }
}
