using DevourDev.Unity.NovelEngine.Entities.Interfaces;

namespace DevourDev.Unity.NovelEngine.Entities
{
    [System.Serializable]
    public struct VariableCondition<T>
    {
        public Character Character;
        public NovelVariable<T> Variable;
        public MathEquation Equation;
        public T Value;
    }

}
