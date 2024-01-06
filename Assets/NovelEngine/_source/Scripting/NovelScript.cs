using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TextCore.Text;
using VisualNovel.Commands;
using VisualNovel.Entities;

namespace VisualNovel.Scripting
{
    public abstract partial class NovelScript
    {



        private readonly ICollection<StoryLineSO> _storyLines;
        private StoryLineSO _initialStoryLine;


        //protected bool IsPersistent {get;set;}


        protected abstract void BuildScript(IScriptBuilder scriptBuilder);
    }
}
