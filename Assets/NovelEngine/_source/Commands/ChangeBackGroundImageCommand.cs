using UnityEngine;
using VisualNovel.CommandSystem;

namespace VisualNovel.Commands
{
    [CreateAssetMenu(menuName = NovelEngineConstants.Commands + nameof(ChangeBackGroundImageCommand))]
    public sealed class ChangeBackGroundImageCommand : CommandSO, ICommand
    {
        [SerializeField] private Sprite _sprite;


        public Sprite Sprite => _sprite;


        public static ChangeBackGroundImageCommand Create(Sprite sprite)
        {
            var inst = ScriptableObject.CreateInstance<ChangeBackGroundImageCommand>();
            inst._sprite = sprite;
            return inst;
        }
    }
}
