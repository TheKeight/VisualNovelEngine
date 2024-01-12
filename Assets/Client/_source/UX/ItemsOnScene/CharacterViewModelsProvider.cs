using DevourDev.Unity.NovelEngine.Entities;
using NovelEngine.Utility;
using UnityEngine;

namespace NovelEngine.CommandHandlers.UX
{
    [CreateAssetMenu(menuName = "Visual Novel/Client/CharacterVM Provider")]
    public sealed class CharacterViewModelsProvider : GameObjectsProviderSO<Character, CharacterOnScene>
    {
    }
}