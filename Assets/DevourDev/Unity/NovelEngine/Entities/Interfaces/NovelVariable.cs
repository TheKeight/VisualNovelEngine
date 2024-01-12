using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Entities.Interfaces
{
    public abstract class NovelVariable<T> : NovelEntity
    {
        [SerializeField] private string _variableName;


        public string VariableName => _variableName;


        public abstract T Add(T a, T b);
        public abstract T Subtract(T a, T b);
        public abstract T Multiply(T a, T b);
        public abstract T Divide(T a, T b);
        public abstract bool AreEqual(T a, T b);
        public abstract bool AreNotEqual(T a, T b);
        public abstract bool IsGreaterThan(T a, T b);
        public abstract bool IsLessThan(T a, T b);
    }

}
