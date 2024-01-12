using UnityEngine;

namespace DevourDev.Unity.NovelEngine.Entities
{
    [System.Serializable]
    public struct SelectorVariant
    {
        [SerializeField] private string _title;
        [SerializeField] private StoryLine _destination;


        public SelectorVariant(string title, StoryLine destination)
        {
            _title = title;
            _destination = destination;
        }


        public readonly string Title => _title;
        public readonly StoryLine Destination => _destination;
    }

}
