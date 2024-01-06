using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using VisualNovel.Commands;
using VisualNovel.Entities;

namespace VisualNovel.Scripting
{
    public sealed class ScriptBuilder : IScriptBuilder
    {
        private readonly Dictionary<string, List<CommandSO>> _storyLines = new();
        private List<CommandSO> _initialStoryLine;
        private List<CommandSO> _currentStoryLine;


        public void Build(out StoryLineSO[] storyLines, out int initialStoryLineIndex)
        {
            throw new NotImplementedException();
        }

        public IScriptBuilder SetStartLabel(string labelName)
        {
            _initialStoryLine = _storyLines[labelName];
            Assert.IsNotNull(_initialStoryLine, $"Label with name {labelName} is not existing to set as initial");
            return this;
        }

        public IScriptBuilder BeginLabel(string labelName)
        {
            Assert.IsNull(_currentStoryLine);

            if (!_storyLines.TryGetValue(labelName, out _currentStoryLine))
            {
                _currentStoryLine = new();
                _storyLines[labelName] = _currentStoryLine;
            }

            _initialStoryLine ??= _currentStoryLine;
            return this;
        }

        public IScriptBuilder EndLabel()
        {
            AssertCurrentStoryLineIsReady();
            _currentStoryLine = null;
            return this;
        }

        public IScriptBuilder Say(CharacterSO character, string text)
        {
            AddCommand(SayCommand.Create(character, text));
            return this;
        }

        public IScriptBuilder Say(CharacterSO character, IEnumerable<string> texts)
        {
            var sayCommands = new SayCommand[texts.Count()];
            int i = 0;

            foreach (var txt in texts)
            {
                sayCommands[i++] = SayCommand.Create(character, txt);
            }

            AddCommands(sayCommands);
            return this;
        }

        public IScriptBuilder Say(string text)
        {
            return Say(null, text);
        }

        public IScriptBuilder Say(IEnumerable<string> texts)
        {
            return Say(null, texts);
        }

        public IScriptBuilder Show(CharacterSO character, ScenePositionSO position)
        {
            return Show(character, position, null);
        }

        public IScriptBuilder Show(CharacterSO character, ScenePositionSO position, AppearanceKeySO appearanceKey)
        {
            AddCommand(ShowCharacterCommand.Create(character, position, appearanceKey));
            return this;
        }

        public IScriptBuilder Show(ItemSO item, ScenePositionSO position)
        {
            AddCommand(ShowItemCommand.Create(item, position, null));
            return this;
        }

        public IScriptBuilder Hide(CharacterSO character)
        {
            AddCommand(HideCharacterCommand.Create(character));
            return this;
        }

        public IScriptBuilder Hide(ItemSO item)
        {
            AddCommand(HideItemCommand.Create(item));
            return this;
        }

        public IScriptBuilder Move(CharacterSO character, ScenePositionSO position)
        {
            AddCommand(MoveCharacterCommand.Create(character, position));
            return this;
        }

        public IScriptBuilder Move(ItemSO item, ScenePositionSO position)
        {
            AddCommand(MoveItemCommand.Create(item, position));
            return this;
        }

        public IScriptBuilder ChangeAppearance(CharacterSO character, AppearanceKeySO appearanceKey)
        {
            AddCommand(ChangeCharacterAppearanceCommand.Create(character, appearanceKey));
            return this;
        }

        public IScriptBuilder ChangeBackGroundImage(Sprite sprite)
        {
            AddCommand(ChangeBackGroundImageCommand.Create(sprite));
            return this;
        }

        public IScriptBuilder ChangeBackGroundMusic(AudioPlaylist playlist)
        {
            AddCommand(ChangeBackGroundMusicCommand.Create(playlist));
            return this;
        }

        public IScriptBuilder PlaySound(AudioClip sound)
        {
            AddCommand(PlaySoundCommand.Create(sound));
            return this;
        }

        public IScriptBuilder Jump(string labelName)
        {
            throw new NotImplementedException();
            AddCommand(JumpToStoryLineCommand.Create(null));

            return this;
        }

        private void AddCommand(CommandSO command)
        {
            AssertCurrentStoryLineIsReady();
            _currentStoryLine.Add(command);
        }

        private void AddCommands(IEnumerable<CommandSO> commands)
        {
            AssertCurrentStoryLineIsReady();
            _currentStoryLine.AddRange(commands);
        }

        private void AssertCurrentStoryLineIsReady()
        {
            Assert.IsNotNull(_currentStoryLine);
        }
    }
}
