using VisualNovel.Commands;
using VisualNovel.Entities;

namespace VisualNovel.Scripting.Commands
{
    public sealed class SayCommandBuilder : CommandBuilder<SayCommand>
    {
        public CharacterSO Character { get; set; }
        public string Text { get; set; }

      
        //protected override SayCommand BuildConcreteInternal()
        //{
        //    return SayCommand.Create(Character, Text);
        //}
    }
}
