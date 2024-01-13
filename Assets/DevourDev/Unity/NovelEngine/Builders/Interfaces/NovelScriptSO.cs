using DevourDev.Unity.NovelEngine.Builders.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Builders.Interfaces
{
    public abstract class NovelScriptSO : ScriptableObject, INovelScriptBuilder
    {
        public abstract NovelScriptData Build();
    }
}
