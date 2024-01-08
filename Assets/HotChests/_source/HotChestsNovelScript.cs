using UnityEngine;
using VisualNovel.Scripting;
using VisualNovel.Utility;

using static VisualNovel.HotChests.FastAccess;

namespace VisualNovel.HotChests
{
    public sealed class HotChestsNovelScript : MonoBehaviour, IBuilder<NovelScriptData>
    {
        public NovelScriptData Build()
        {
            const string StartLabel = "Start";
            const string GoToKitchenLabel = "Go to kitchen";
            const string GoOutLabel = "Go out";
            const string ShitOnTheFloorLabel = "Shit on the floor";

            var builder = new NovelScriptBuilder();
            builder.BeginLabel(StartLabel)
                   .ChangeBackGroundMusic(RoutinePlaylist)
                   .Say(MC, "Fuuuuck, shieeeeet...",
                        "biiiiiiitch..!!!",
                        "sheeeeaaat...",
                        "...")
                   .ChangeBackGroundImage(McHomeBG)
                   .Say(MC, "fuuuck...")
                   .Show(MC, CenterPosition)
                   .Say(MC, "fuuuuuck assss huuui!!!")
                   .Move(MC, RightPosition)
                   .Move(MC, LeftPosition)
                   .ShowSelector("wat 2 do?",
                                 new SelectorVariantBuilder() { Title = "aaaah ffff...", StoryLineBuilder = builder.GetLabel(GoToKitchenLabel) },
                                 new SelectorVariantBuilder() { Title = "go out", StoryLineBuilder = builder.GetLabel(GoOutLabel) })
                   .EndLabel();

            builder.BeginLabel(GoToKitchenLabel)
                   .Move(MC, CenterPosition)
                   .Move(MC, RightPosition)
                   .Hide(MC)
                   .ChangeBackGroundImage(McHomeBG)
                   .Say(MC, "I've cum to kitchen!")
                   .ShowSelector("SHIT ON THE FLOOR?",
                                 new SelectorVariantBuilder() { Title = "yeeeaah!", StoryLineBuilder = builder.GetLabel(ShitOnTheFloorLabel) },
                                 new SelectorVariantBuilder() { Title = "naaaah...", StoryLineBuilder = builder.GetLabel(GoOutLabel) })
                   .EndLabel();

            builder.BeginLabel(GoOutLabel)
                   .Move(MC, CenterPosition)
                   .Move(MC, RightPosition)
                   .Hide(MC)
                   .ChangeBackGroundImage(OutdoorsBG)
                   .ChangeBackGroundMusic(DepressionPlaylist)
                   .EndLabel();

            builder.BeginLabel(ShitOnTheFloorLabel)
                   .Move(MC, CenterPosition)
                   .Say(MC, "UFFFFF...",
                            "I'VE SHIT SO HAAARD!!!")
                   .EndLabel();

            return builder.Build();
        }
    }
}
