using DevourDev.Unity.NovelEngine.Entities;

namespace DevourDev.Unity.NovelEngine.Builders.Entities
{
    public readonly struct NovelScriptData
    {
        private readonly StoryLine[] _storyLines;
        private readonly int _startStoryLineIndex;


        public NovelScriptData(StoryLine[] storyLines, int startStoryLineIndex)
        {
            _storyLines = storyLines;
            _startStoryLineIndex = startStoryLineIndex;
        }


        public StoryLine[] StoryLines => _storyLines;
        public int StartStoryLineIndex => _startStoryLineIndex;
    }
}
