using UnityEngine;
using VisualNovel.Scripting;

namespace VisualNovel.Utility.NovelScripts
{
    public abstract class NovelScriptSO : ScriptableObject, IBuilder<NovelScriptData>
    {
        public abstract NovelScriptData Build();
    }
}
