using DevourDev.Unity.Utility.UI;

namespace DevourDev.Unity.NovelEngine.Entities
{
    public interface ICharacter
    {
        string CharacterName { get; }
        TextMeshProDesign NameTextDesign { get; }
        TextMeshProDesign SpeechTextDesign { get; }
    }

}
