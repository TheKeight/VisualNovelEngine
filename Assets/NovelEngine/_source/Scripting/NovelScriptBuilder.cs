using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using VisualNovel.Commands;
using VisualNovel.Entities;
using VisualNovel.Scripting.CommandBuilders;
using VisualNovel.Scripting.EntityBuilders;
using VisualNovel.Utility;

namespace VisualNovel.Scripting
{
    public sealed class NovelScriptBuilder : IScriptBuilder
    {
        private readonly Dictionary<string, StoryLineBuilder> _storyLines = new();
        private StoryLineBuilder _initialStoryLine;
        private StoryLineBuilder _currentStoryLine;


        public IScriptBuilder SetStartLabel(string labelName)
        {
            _initialStoryLine = _storyLines[labelName];
            Assert.IsNotNull(_initialStoryLine, $"Label with name {labelName} is not existing to set as initial");
            return this;
        }

        public IScriptBuilder BeginLabel(string labelName)
        {
            Assert.IsNull(_currentStoryLine);
            _currentStoryLine = GetOrCreateStoryLineBuilder(labelName);
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

        public IScriptBuilder Say(CharacterSO character, params string[] texts)
            => Say(character, (IEnumerable<string>)texts);

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
            var storyLineBuilder = GetOrCreateStoryLineBuilder(labelName);
            IBuilder<JumpToStoryLineCommand> jumpCommandBuilder = new JumpToStoryLineCommandBuilder(storyLineBuilder);
            AddCommand(jumpCommandBuilder);

            return this;
        }

        public IScriptBuilder ShowSelector(string title, params SelectorVariantBuilder[] variants)
        {
            return ShowSelector(title, (IEnumerable<SelectorVariantBuilder>)variants);
        }

        public IScriptBuilder ShowSelector(string title, IEnumerable<SelectorVariantBuilder> variants)
        {
            var cmdBuilder = new ShowSelectorCommandBuilder()
            {
                Title = title,
                Variants = variants.ToList()
            };

            AddCommand(cmdBuilder);
            return this;
        }

        public IBuilder<StoryLineSO> GetLabel(string labelName)
        {
            return GetOrCreateStoryLineBuilder(labelName);
        }

        public NovelScriptData Build()
        {
            var data = new NovelScriptData();
            StoryLineBuilder[] slBuilders = _storyLines.Values.ToArray();
            data.InitialStoryLineIndex = Array.IndexOf(slBuilders, _initialStoryLine);
            data.StoryLines = Array.ConvertAll(slBuilders, builder => builder.Build());
            return data;
        }

        private StoryLineBuilder GetOrCreateStoryLineBuilder(string labelName)
        {
            if (!_storyLines.TryGetValue(labelName, out var storyLineBuilder))
            {
                storyLineBuilder = new StoryLineBuilder();
                _storyLines[labelName] = storyLineBuilder;
            }

            return storyLineBuilder;
        }

        private void AddCommand(CommandSO command)
        {
            AssertCurrentStoryLineIsReady();
            _currentStoryLine.AddCommand(command);
        }

        private void AddCommand<TCmd>(IBuilder<TCmd> commandBuilder)
            where TCmd : CommandSO
        {
            AssertCurrentStoryLineIsReady();
            _currentStoryLine.AddCommand(commandBuilder);
        }

        private void AddCommands(IEnumerable<CommandSO> commands)
        {
            AssertCurrentStoryLineIsReady();
            _currentStoryLine.AddCommands(commands);
        }

        private void AssertCurrentStoryLineIsReady()
        {
            Assert.IsNotNull(_currentStoryLine);
        }
    }
}
