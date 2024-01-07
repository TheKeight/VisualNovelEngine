using VisualNovel.Commands;

namespace VisualNovel.Scripting.Commands
{
    public sealed class HideCharacterCommandBuilder : CommandBuilder<HideCharacterCommand>
    {
        public CharacterBuilder CharacterBuilder { get; set; }


        protected override HideCharacterCommand BuildConcrete()
        {
            return HideCharacterCommand.Create(CharacterBuilder.BuildConcrete());
        }
    }
}
