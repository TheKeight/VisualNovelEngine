using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using NovelEngine.Entities.Interface;
using UnityEngine;

namespace NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(ChangeBackGroundCommand))]
    public sealed class ChangeBackGroundCommand : NovelCommand
    {
        [SerializeField] private BackGround _backGround;


        public BackGround BackGround => _backGround;


        public static ChangeBackGroundCommand Create(BackGround backGround)
        {
            var inst = CreateInstance<ChangeBackGroundCommand>();
            inst._backGround = backGround;
            return inst;
        }
    }
}
