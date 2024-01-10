using UnityEngine;
using VisualNovel.Entities;
using VisualNovel.Scripting;
using VisualNovel.Utility.NovelScripts;

namespace VisualNovel.HotChests
{
    [CreateAssetMenu(menuName = "Visual Novel/HotChests/Test2 Script")]
    public sealed class Test2NovelScript : NovelScriptSO
    {
        [Header("Backgrounds")]
        [SerializeField] private Sprite _forestDayBg;
        [SerializeField] private Sprite _forestMidBg;
        [SerializeField] private Sprite _forestNightBg;

        [Header("Characters")]
        [SerializeField] private CharacterSO _pupa;
        [SerializeField] private CharacterSO _lupa;
        [SerializeField] private CharacterSO _buhgalter;

        [Header("Audio")]
        [SerializeField] private AudioPlaylist _happyPlaylist;
        [SerializeField] private AudioPlaylist _sadPlaylist;


        public override NovelScriptData Build()
        {
            const string WelcomeLabel = "Welcome";
            const string FeedToPigsLabel = "FeedToPigs";
            const string UnderstandAndHaveMercyLabel = "UnderstandAndHaveMercy";

            var builder = new NovelScriptBuilder();

            /*
            builder.BeginLabel(WelcomeLabel)
                .ChangeBackGroundImage(_forestDayBg)
                .ChangeBackGroundMusic(_happyPlaylist)
                .Say("Это тестовый сценарий для визуальной новеллы")
                .Say("Назовём его \"Случай в бухгалтерии\"")
                .Show(_pupa, FastAccess.CenterPosition)
                .Say("Это Артём Анатольевич Пупов")
                .Say("Для друзей - просто Пупа")
                .Move(_pupa, FastAccess.LeftPosition)
                .Show(_lupa, FastAccess.CenterPosition)
                .Say("А это - его коллега")
                .Say("Павел Сергеевич Лупаков")
                .Say("И, как вы догадались, чаще всего его называют Лупой")
                .Move(_lupa, FastAccess.RightPosition)
                .Say(_pupa, "Привет, Лупа!")
                .Say(_lupa, "Привет, Пупа!")
                .Say(_pupa, "Отличный сегодня денёк, а?")
                .Say(_lupa, "Хуй на! Забыл, что-ли?")
                .Say(_pupa, "Че забыл?")
                .Say(_lupa, "Э-э-эх...")
                .Say(_lupa, "Забей")
                .Say(_pupa, "?")
                .Say(_pupa, "Ладно...")
                .Say("Пупа, действительно, забыл, что сегодня за день. Оно и не удивительно - " +
                "вчера Пупа отмечал своё 40-летие. Здорово, что он сегодня на своё имя откликается...")
                .Say("Тем не менее, сегодня был день \"получки\"")
                .ChangeBackGroundImage(_forestMidBg)
                .ChangeBackGroundMusic(_sadPlaylist)
                .Show(_buhgalter, FastAccess.CenterPosition)
                .Say(_buhgalter, "Пупов, подойдите к кассе")
                .Say(_pupa, "Зачем?")
                .Say(_buhgalter, "Чтобы получить заработную плату за февраль")
                .Say(_lupa, "Так сейчас август")
                .Say(_buhgalter, "А, да, точно")
                .Say(_buhgalter, "Извините, я здесь недавно")
                .Say(_lupa, "Ну да, у нас-то здесь другое летоисчисление")
                .Say(_pupa, "Так сейчас же зима")
                .Say(_lupa, "Зима сейчас только у тебя")
                .Say(_lupa, "И то, если ты, наконец, помоешь свою голову, то с неё перестанет сыпаться \"снег\"")
                .Say(_lupa, "И даже в семье Пуповых закончится ледниковый период")
                .Say(_buhgalter, "С позволения сказать, мы все сейчас живем в ледниковый период, а, если быть точным, " +
                "в период межледниковья...")
                .Say(_lupa, "С позволения сказать, завали ебало!")
                .Say(_buhgalter, "Хуя, дерзкий - по горшкам дежурный")
                .Say(_pupa, "ГДЕ МОИ ДЕНЬГИ БРРГЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫЫ")
                .Say(_buhgalter, "Так, посмотрим...")
                .Say(_buhgalter, "Василий Ротодубов, Владимир Яснозоров, Крабдмир...")
                .Say(_pupa, "АуууУуУУуу!!!111")
                .Say(_buhgalter, "Да, конечно, вот")
                .Say("Изрядно напуганный бухгалтер второпях отсчитывает Пупову и Лупакову их кровные и удаляется.")
                .Hide(_buhgalter)
                .ChangeBackGroundImage(_forestDayBg)
                .ChangeBackGroundMusic(_happyPlaylist)
                .Say(_lupa, "С прошедшим, Пупа!")
                .Say(_pupa, "Спасибо, Лупа!")
                .Hide(_pupa)
                .Hide(_lupa)
                .Say("На следующий день 2 коллеги встретились вновь")
                .Say(_pupa, "ААААААААА")
                .Say(_pupa, "ООООООООО")
                .Say(_pupa, "БАМАНУЛИ!!!!!")
                .Say(_lupa, "Где этот козел?!")
                .ChangeBackGroundImage(_forestNightBg)
                .ChangeBackGroundMusic(_sadPlaylist)
                .Show(_pupa, FastAccess.LeftPosition)
                .Show(_lupa, FastAccess.CenterPosition)
                .Show(_buhgalter, FastAccess.RightPosition)
                .Say(_buhgalter, "Новый бухгалтер Козлов, чем могу быть полезен?")
            */
            builder.BeginLabel(WelcomeLabel);
            builder.Say(_pupa, "Ты опять нас обманул!");
            builder.Say(_lupa, "Козел!");
            builder.Say(_buhgalter, "Никого я не обманывал");
            builder.ShowSelector("Что делать с козлом?", new SelectorVariantBuilder[]
            {
                    new(){Title = "скормить свиньям", StoryLineBuilder = builder.GetLabel(FeedToPigsLabel)},
                    new(){Title = "понять и простить", StoryLineBuilder = builder.GetLabel(UnderstandAndHaveMercyLabel)}
            });
            builder.EndLabel();

            builder.BeginLabel(FeedToPigsLabel)
                .Say(_pupa, "Ты заплатил мне ЗА ЛУПУ!")
                .Say(_lupa, "А мне - ЗА ПУПУ!")
                .Say(_buhgalter, "Простите меня, я, бухгалтер, опять все перепутал!")
                .Say(_pupa, "Ах, ты, ебаный бюстгальтер")
                .Say(_pupa, "Теперь ты - корм для рыб...")
                .Say(_lupa, "Свиньям")
                .Say(_pupa, "Точно!")
                .Hide(_buhgalter)
                .Say("Вот так, бухгалтера съели свиньи")
                .Say("Охуенная концовка")
                .EndLabel();

            builder.BeginLabel(UnderstandAndHaveMercyLabel)
                .ChangeBackGroundImage(_forestMidBg)
                .ChangeBackGroundMusic(_happyPlaylist)
                .Say(_lupa, "Кажется, в бухгалтерии опять все перепутали")
                .Say(_lupa, "Я получил за Пупу, а Пупа, в свою очередь, получил за меня, Лупу")
                .Say(_buhgalter, "Я прекрасно понимаю, что вы оба сейчас чувствуете. Пожалуйста, позвольте мне всё исправить.")
                .Say(_buhgalter, "Уверяю вас, это не займет много времени!")
                .Hide(_buhgalter)
                .Say("В тот же час бухгалтер уволился и улетел в Африку - дрессировать бегемотов")
                .Say("Пупов и Лупанов остались при своём, но они не расстроились")
                .Say(_lupa, "Какая разница, кто за кого получил, если у нас всех одинаковая зарплата")
                .Say(_pupa, "Верно, коллега, я спать пошел!")
                .Say("Пупа и Лупа разошлись по домам")
                .Say("В ту ночь все спали спокойно")
                .Say("Особенно свиньи - они умерли с голоду")
                .Say("Голодная концовка")
                .Jump(WelcomeLabel)
                .EndLabel();

            return builder.Build();
        }
    }
}
