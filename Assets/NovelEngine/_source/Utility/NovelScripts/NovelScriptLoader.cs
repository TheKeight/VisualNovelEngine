using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using VisualNovel.Engine;
using VisualNovel.Scripting;

namespace VisualNovel.Utility.NovelScripts
{
    public sealed class NovelScriptLoader : MonoBehaviour
    {
        [SerializeField] private SerializedInterface<INovelController> _novelController;
        [SerializeField] private SerializedInterface<IBuilder<NovelScriptData>> _novelScript;


        private void Awake()
        {
            var data = _novelScript.Item.Build();
            _novelController.Item.SetStoryLine(data.StoryLines[data.InitialStoryLineIndex]);
            _novelController.Item.GoNext();
        }
    }
}
