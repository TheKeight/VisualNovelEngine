using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using UnityEngine;

namespace NovelEngine.UX.Variables
{
    public sealed class NovelVariablesManager : MonoBehaviour
    {
        private readonly Dictionary<Character, NovelVariablesCollection> _variables = new();


        public T GetCharacterVariableValue<T>(Character character, NovelVariable<T> variable)
        {
            var collection = GetOrCreateVariablesCollection(character);
            var currentValue = collection.GetValueOrDefault(variable);
            return currentValue;
        }

        public void ChangeCharacterVariable<T>(Character character, NovelVariable<T> variable,
            MathOperation operation, T value)
        {
            var collection = GetOrCreateVariablesCollection(character);
            var currentValue = collection.GetValueOrDefault(variable);
            var newValue = NovelVariablesHelpers.ComputeMathOperation(variable, currentValue, operation, value);
            collection.SetValue(variable, newValue);
        }


        private NovelVariablesCollection GetOrCreateVariablesCollection(Character character)
        {
            if (!_variables.TryGetValue(character, out var collection))
            {
                collection = new();
                _variables[character] = collection;
            }

            return collection;
        }
    }
}
