using System.Collections.Generic;
using UnityEngine;
using VisualNovel.Entities;
using VisualNovel.Utility;

namespace VisualNovel.Scripting
{
    public interface IScriptBuilder : IBuilder<NovelScriptData>
    {
        IScriptBuilder SetStartLabel(string labelName);
        IScriptBuilder BeginLabel(string labelName);
        IScriptBuilder EndLabel();
        IScriptBuilder Say(CharacterSO character, string message);
        IScriptBuilder Say(CharacterSO character, params string[] messages);
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
        IScriptBuilder ShowSelector(string title, params SelectorVariantBuilder[] variants);
        IScriptBuilder ShowSelector(string title, IEnumerable<SelectorVariantBuilder> variants);
        IBuilder<StoryLineSO> GetLabel(string labelName);

        // TODO: handle minigame progress and result
        //IScriptBuilder StartMiniGame<TMiniGame>();
    }
}
