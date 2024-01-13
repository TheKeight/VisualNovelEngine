using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.UX.Variables;

namespace NovelEngine.UX.ItemsOnScene
{
    public abstract class CharacterOnScene : NovelEntityOnScene<Character>
    {
        private readonly NovelVariablesCollection _variablesCollection = new();


        public NovelVariablesCollection VariablesCollection => _variablesCollection;
    }
}