using System.Collections.Generic;
using System.Linq;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ShowSelectorCommand))]
    public sealed class ShowSelectorCommand : NovelCommand
    {
        [SerializeField] private string _title;
        [SerializeField] private SelectorVariant[] _variants;


        public string Title => _title;
        public IReadOnlyList<SelectorVariant> Variants => _variants;


        public static ShowSelectorCommand Create(string title, IEnumerable<SelectorVariant> variants)
        {
            var inst = CreateInstance<ShowSelectorCommand>();
            inst._title = title;
            inst._variants = variants.ToArray();
            return inst;
        }
    }
}
