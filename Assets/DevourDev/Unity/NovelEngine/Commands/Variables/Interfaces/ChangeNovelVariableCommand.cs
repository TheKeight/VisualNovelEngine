using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands.Variables.Interfaces
{
    public abstract class ChangeNovelVariableCommand<T> : NovelCommand
    {
        [SerializeField] private Character _character;
        [SerializeField] private NovelVariable<T> _variable;
        [SerializeField] private MathOperation _operation;
        [SerializeField] private T _value;


        public Character Character => _character;
        public NovelVariable<T> Variable => _variable;
        public MathOperation Operation => _operation;
        public T Value => _value;


        protected void Init(Character character,
            NovelVariable<T> variable, MathOperation operation, T value)
        {
            _character = character;
            _variable = variable;
            _operation = operation;
            _value = value;
        }
    }
}
