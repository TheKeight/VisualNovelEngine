using System;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;

namespace NovelEngine.UX.Variables
{
    public static class NovelVariablesHelpers
    {
        public static T ComputeMathOperation<T>(NovelVariable<T> variable, T valueA, MathOperation mathOperation, T valueB)
        {
            return mathOperation switch
            {
                MathOperation.Set => variable.Set(valueA, valueB),
                MathOperation.Add => variable.Add(valueA, valueB),
                MathOperation.Subtract => variable.Subtract(valueA, valueB),
                MathOperation.Multiply => variable.Multiply(valueA, valueB),
                MathOperation.Divide => variable.Divide(valueA, valueB),
                _ => throw new NotImplementedException(),
            };
        }

        public static bool SolveMathEquation<T>(NovelVariable<T> variable, T valueA, MathEquation mathEquation, T valueB)
        {
            return mathEquation switch
            {
                MathEquation.AreEqual => variable.AreEqual(valueA, valueB),
                MathEquation.AreNotEqual => variable.AreNotEqual(valueA, valueB),
                MathEquation.IsGreaterThan => variable.IsGreaterThan(valueA, valueB),
                MathEquation.IsLessThan => variable.IsLessThan(valueA, valueB),
                _ => throw new NotImplementedException()
            };
        }
    }
}
