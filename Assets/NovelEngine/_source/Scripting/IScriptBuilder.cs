using System.Collections.Generic;
using UnityEngine;
using VisualNovel.Entities;

namespace VisualNovel.Scripting
{
    public interface IScriptBuilder
    {
        void Build(out StoryLineSO[] storyLines, out int initialStoryLineIndex);
        IScriptBuilder SetStartLabel(string labelName);
        IScriptBuilder BeginLabel(string labelName);
        IScriptBuilder EndLabel();
        IScriptBuilder Say(CharacterSO character, string message);
        IScriptBuilder Say(CharacterSO character, IEnumerable<string> messages);
        IScriptBuilder Say(string message);
        IScriptBuilder Say(IEnumerable<string> messages);
        IScriptBuilder Show(CharacterSO character, ScenePositionSO position);
        IScriptBuilder Show(CharacterSO character, ScenePositionSO position, AppearanceKeySO appearanceKey);
        IScriptBuilder Show(ItemSO item, ScenePositionSO position);
        IScriptBuilder Hide(CharacterSO character);
        IScriptBuilder Hide(ItemSO item);
        IScriptBuilder Move(CharacterSO character, ScenePositionSO position);
        IScriptBuilder Move(ItemSO item, ScenePositionSO position);
        IScriptBuilder ChangeAppearance(CharacterSO character, AppearanceKeySO appearanceKey);
        IScriptBuilder ChangeBackGroundImage(Sprite sprite);
        IScriptBuilder ChangeBackGroundMusic(AudioPlaylist playlist);
        IScriptBuilder PlaySound(AudioClip sound);
        IScriptBuilder Jump(string labelName);

        // TODO: handle minigame progress and result
        //IScriptBuilder StartMiniGame<TMiniGame>();
    }
}
