using UnityEngine;
using VisualNovel.Client.Utility;
using VisualNovel.Entities;

namespace VisualNovel.Client.UX
{
    [CreateAssetMenu(menuName = "Visual Novel/Client/CharacterVM Provider")]
    public sealed class CharacterViewModelsProvider : GameObjectsProviderSO<CharacterSO, CharacterOnScene>
    {
    }
}