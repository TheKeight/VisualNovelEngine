using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using DevourDev.Unity.Utility.UI;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Entities
{

    [CreateAssetMenu(menuName = EntitiesConstants.Entities + nameof(Character))]
    public sealed class Character : NovelEntity
    {
        [SerializeField] private string _characterName;
        [SerializeField] private TextMeshProDesign _nameTextDesign;
        [SerializeField] private TextMeshProDesign _speechTextDesign;


        public string CharacterName => _characterName;
        public TextMeshProDesign NameTextDesign => _nameTextDesign;
        public TextMeshProDesign SpeechTextDesign => _speechTextDesign;


        public static Character Create(string characterName, TextMeshProDesign nameTextDesign, TextMeshProDesign speechTextDesign)
        {
            var inst = CreateInstance<Character>();
            inst._characterName = characterName;
            inst._nameTextDesign = nameTextDesign;
            inst._speechTextDesign = speechTextDesign;
            return inst;
        }

        public override string ToString()
        {
            return $"{base.ToString()} ({_characterName})";
        }
    }

}
