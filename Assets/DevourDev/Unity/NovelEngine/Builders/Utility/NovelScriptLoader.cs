using DevourDev.Unity.NovelEngine.Builders.Interfaces;
using DevourDev.Unity.NovelEngine.Core;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Builders.Utility
{
    public sealed class NovelScriptLoader : MonoBehaviour
    {
        [SerializeField] private NovelScriptSO _novelScript;
        [SerializeField] private NovelControllerComponent _novelController;


        private void Start()
        {
            var data = _novelScript.Build();
            _novelController.SetStoryLine(data.StoryLines[data.StartStoryLineIndex], 0);
            _novelController.GoNext();
        }
    }
}
