using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace NovelEngine.Commands.MiniGames
{
    public sealed class StartNsfwMiniGameCommand : NovelCommand
    {
        [SerializeField] private StoryLine _bDestination;


        public StoryLine BDestination => _bDestination;


        public static StartNsfwMiniGameCommand Create(StoryLine bDestination)
        {
            var inst = CreateInstance<StartNsfwMiniGameCommand>();
            inst._bDestination = bDestination;
            return inst;
        }
    }
}
