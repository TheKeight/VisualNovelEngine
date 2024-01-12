using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Entities
{
    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(IntegerNovelVariable))]
    public sealed class IntegerNovelVariable : NovelVariable<int>
    {
        public override int Add(int a, int b) => a + b;

        public override int Subtract(int a, int b) => a - b;

        public override int Multiply(int a, int b) => a * b;

        public override int Divide(int a, int b) => a / b;

        public override bool AreEqual(int a, int b) => a == b;

        public override bool AreNotEqual(int a, int b) => a != b;

        public override bool IsGreaterThan(int a, int b) => a > b;

        public override bool IsLessThan(int a, int b) => a < b;
    }

}
