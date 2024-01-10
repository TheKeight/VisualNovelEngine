using UnityEngine;
using VisualNovel.Engine;

namespace VisualNovel.Utility.NovelScripts
{
    [DefaultExecutionOrder(5000)]
    public sealed class NovelScriptLoader : MonoBehaviour
    {
        [SerializeField] private NovelControllerComponent _novelController;
        [SerializeField] private NovelScriptSO _novelScript;


        private void Awake()
        {
            var data = _novelScript.Build();
            _novelController.SetStoryLine(data.StoryLines[data.InitialStoryLineIndex], 0);
            _novelController.GoNext();
        }
    }
}
