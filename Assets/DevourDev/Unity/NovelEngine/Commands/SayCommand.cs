using DevourDev.Unity.NovelEngine.Commands.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Commands
{
    [CreateAssetMenu(menuName = CommandsConstants.Commands + nameof(SayCommand))]
    public sealed class SayCommand : NovelCommand
    {
        [SerializeField] private Character _speaker;
        [SerializeField] private string _speakerNameOverride;
        [SerializeField] private string _speech;


        public Character Character => _speaker;
        public string SpeakerNameOverride => _speakerNameOverride;
        public string Speech => _speech;


        public static SayCommand Create(Character speaker, string speech)
        {
            var inst = CreateInstance<SayCommand>();
            inst._speaker = speaker;
            inst._speech = speech;
            return inst;
        }

        public static SayCommand Create(string speakerNameOverride, string speech)
        {
            var inst = CreateInstance<SayCommand>();
            inst._speaker = null;
            inst._speakerNameOverride = speakerNameOverride;
            inst._speech = speech;
            return inst;
        }
    }


}
