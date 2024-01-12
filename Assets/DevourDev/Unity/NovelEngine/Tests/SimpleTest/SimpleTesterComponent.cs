using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Tests.SimpleTest
{
    public sealed class SimpleTesterComponent : MonoBehaviour
    {
        private void Start()
        {
            SimpleTestHelpers.RunSimpleTester();
        }
    }
}
