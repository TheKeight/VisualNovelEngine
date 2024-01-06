using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VisualNovel.CommandSystem;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ShowSelectorCommand))]
    public sealed class ShowSelectorCommand : CommandSO, ICommand
    {
        [System.Serializable]
        public sealed class Variant : ISelectorVariant
        {
            [SerializeField] private string _title;
            [SerializeField] private CommandSO[] _commands;


            public string Title => _title;
            public IReadOnlyList<CommandSO> Commands => _commands;


            public static Variant Create(string title, IEnumerable<CommandSO> commands)
            {
                var inst = new Variant();
                inst._title = title;
                inst._commands = commands.ToArray();
                return inst;
            }
        }


        [SerializeField] private string _title;
        [SerializeField] private Variant[] _variants;


        public string Title => _title;
        public IReadOnlyList<ISelectorVariant> Variants => _variants;


        public static ShowSelectorCommand Create(string title, IEnumerable<Variant> variants)
        {
            var inst = CreateInstance<ShowSelectorCommand>();
            inst._title = title;
            inst._variants = variants.ToArray();
            return inst;
        }
    }
}
