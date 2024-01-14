using System;
using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Builders.BaseBuilder;
using DevourDev.Unity.NovelEngine.Builders.Entities;
using DevourDev.Unity.NovelEngine.Builders.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using NovelEngine.Entities;
using NovelEngine.Entities.Interface;
using NovelEngine.Tagging;
using UnityEngine;

using static NovelEngine.HotChests200.NovelScripting.NovelTagsManager;

namespace NovelEngine.HotChests200.NovelScripting
{
    [CreateAssetMenu(menuName = "HotChests/NovelScript")]
    internal class HotChestsNovelScript : NovelScriptSO
    {
        [Header("Characters")]
        [SerializeField] private Character _mc;
        [SerializeField] private Character _sonya;

        [Header("Appearance Keys")]
        [SerializeField] private AppearanceKey _holdingTreasureMapAppKey;
        [SerializeField] private AppearanceKey _lookingAtTheMapAppKey;

        [Header("Variables")]
        [SerializeField] private IntegerNovelVariable _superGoodEndingVar;
        [SerializeField] private IntegerNovelVariable _decidedToForgetVar;
        [SerializeField] private IntegerNovelVariable _secretWeaponUsedVar;

        [Header("Sounds")]
        [SerializeField] private Sound _femaleLaughter;
        [SerializeField] private Sound _stepsSoundLoop;
        [SerializeField] private Sound _rainSoundLoop;
        [SerializeField] private Sound _campfireSoundLoop;

        [Header("BGM Playlists")]
        [SerializeField] private AudioPlayList _cityBGM;

        [Header("BackGrounds")]
        [SerializeField] private BackGround _blackScreenBG;
        [SerializeField] private BackGround _officeBG;
        [SerializeField] private BackGround _officeNoiseBG;
        [SerializeField] private BackGround _hotChests200BG;
        [SerializeField] private BackGround _street1BG;
        [SerializeField] private BackGround _street2BG;
        [SerializeField] private BackGround _breadForPoorsBG;
        [SerializeField] private BackGround _breadForPurrsBG;
        [SerializeField] private BackGround _sonyaAndMcHuggingBG;
        [SerializeField] private BackGround _cursedOldHouseBG;
        [SerializeField] private BackGround _cursedOldHouseRainBG;
        [SerializeField] private BackGround _guitarInsideCursedOldHouseBG;
        [SerializeField] private BackGround _campfireAndGuitarInsideCursedOldHouseBG;
        [SerializeField] private BackGround _campfireInsideCursedOldHouseBG;
        [SerializeField] private BackGround _treasures;

        [Header("NOODLES")]
        [SerializeField] private TagSO _noodleTag;
        [SerializeField] private TagSO _mapTag;

        private IEnumerable<TagSO> _noodleMapTagQuery;


        public override NovelScriptData Build()
        {
            _noodleMapTagQuery = new TagSO[] { _noodleTag, _mapTag };

            const string AnonSonyaName = "Странная девушка с картой";
            const string StartLabel = "Start";
            const string OfficeLabel = "Office";
            const string DecideToTryLabel = "DecideToTry";
            const string DecideToForgetLabel = "DecideToForget";
            const string OutOfOfficeLabel = "OutOfOffice";
            const string NonsenseLabel = "Nonsense";
            const string RyanGoslingLabel = "RyanGosling";
            const string OfferHelpLabel = "OfferHelp";
            const string AdventureStartedLabel = "AdventureStarted";
            const string HugSonyaLabel = "HugSonya";
            const string NotHugSonyaLabel = "NotHugSonya";
            const string AdventureContinuedLabel = "AdventureContinued";
            const string ThereAreNoMonstersOnEarthLabel = "ThereAreNoMonstersOnEarth";
            const string ImAfraidOfMonstersLabel = "ImAfraidOfMonsters";
            const string RyanMonsteringLabel = "RyanMonstering";
            const string AfterMonstersLabel = "AfterMonsters";

            const string ElevatorArsonistLabel = "ElevatorArsonist";
            const string MagicianLabel = "Magician";

            const string AfterCampfireLabel = "AfterCampfire";


            var builder = new NovelScriptBuilder();

            #region Start
            builder.BeginLabel(StartLabel);
            builder.ChangeBG(_blackScreenBG);
            MCThink(builder, "Я провожу еще один день, словно оказавшись в замкнутом круге.");
            MCThink(builder, "Просыпаюсь каждое утро с мыслью, что сегодня будет точная копия" +
                " вчерашнего дня: работа, дом.");
            MCThink(builder, "А потом снова и снова, словно день сурка.");
            MCThink(builder, "Всё вокруг меня кажется одинаковым и неинтересным.");
            builder.Jump(OfficeLabel);
            builder.EndLabel();

            builder.BeginLabel(OfficeLabel);
            builder.ChangeBG(_officeBG);
            builder.Delay(2f);
            builder.ChangeBG(_officeNoiseBG);
            builder.Delay(5f);
            builder.ChangeBG(_blackScreenBG);
            MCThink(builder, "Но в один вечер...");
            builder.ChangeBG(_hotChests200BG);
            MCThink(builder, "Проводя своё свободное время за компьютером, я натыкаюсь на" +
                " странную историю о существовании сокровища.");
            MCThink(builder, "Мой интерес сильно возрос, что послужило толчком, который может" +
                " изменить мою жизнь.");
            MCThink(builder, "Несмотря на энтузиазм, я сомневался в существовании сокровища.");
            MCThink(builder, "Это всё может быть лишь выдумкой...");
            MCThink(builder, "...");
            MCThink(builder, "Однако, любопытство внутри меня взяло верх.");
            builder.ChangeBG(_blackScreenBG);
            MCThink(builder, "Переживая внутренний бой между реальностью и фантазией, я решаю...");

            builder.BeginSelector("Переживая внутренний бой между реальностью и фантазией, я решаю...");
            builder.BeginSelectorVariant("...попробовать!");
            builder.EndSelectorVariant(DecideToTryLabel);

            builder.BeginSelectorVariant("...забыть про эту чушь.");
            builder.EndSelectorVariant(DecideToForgetLabel);
            builder.EndSelector();
            builder.EndLabel();
            #endregion

            #region DecideToForget
            builder.BeginLabel(DecideToForgetLabel);
            builder.ChangeVariable(_mc, _decidedToForgetVar, MathOperation.Set, 1);
            builder.Jump(OutOfOfficeLabel);
            builder.EndLabel();
            #endregion

            #region DecideToTry
            builder.BeginLabel(DecideToTryLabel);
            builder.ChangeVariable(_mc, _superGoodEndingVar, MathOperation.Add, 1);
            builder.Jump(OutOfOfficeLabel);
            builder.EndLabel();
            #endregion

            #region OutOfOffice
            builder.BeginLabel(OutOfOfficeLabel);
            builder.ChangeBG(_street1BG);
            builder.ChangeBGM(_cityBGM);
            builder.Delay(2f);
            builder.Show(_sonya, 0.7f, _holdingTreasureMapAppKey);
            builder.Delay(1f);
            MCThink(builder, "Хм...");
            MCThink(builder, "Почему эта девушка держит кусок старой оборванной бумаги?");
            MCThink(builder, "Подойду поближе, чтобы узнать, зачем.");
            builder.BeginSoundLoop(_stepsSoundLoop);
            builder.Delay(2.4f);
            builder.EndSoundLoop(_stepsSoundLoop);
            MCSay(builder, "Привет, что ищешь?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Move(_sonya, 0.5f);
            builder.Say(_sonya, AnonSonyaName, "Привет!");
            builder.Say(_sonya, AnonSonyaName, "Я ищу сокровище.");
            builder.Say(_sonya, AnonSonyaName, "Звучит, наверное, странно...");
            builder.PlaySound(_femaleLaughter);
            builder.Say(_sonya, AnonSonyaName, "*женский смех*");
            //builder.Delay(1f);
            builder.Say(_sonya, AnonSonyaName, "Эта карта...");
            builder.Say(_sonya, AnonSonyaName, "Она указывает на местоположение сокровища.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, AnonSonyaName, "Веришь в такое?");
            MCThink(builder, "Странная она какая-то...");
            MCThink(builder, "Но в глазах видно искры азарта и жажды приключений.");
            MCSay(builder, "Да, я думаю, можно поверить в такие вещи");
            MCSay(builder, "Но как ты узнала о существовании этой карты и что именно ты хочешь найти?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Thinking);
            builder.Delay(1.5f);
            builder.ChangeAppearance(_sonya, _lookingAtTheMapAppKey);
            builder.Delay(2f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, IDunnoLol);
            builder.Say(_sonya, AnonSonyaName, "Увидела объявление в интернете.");
            builder.Say(_sonya, AnonSonyaName, "А живу я не особо богато, поэтому решила, что это мой шанс " +
                @"¯\_(=))_/¯");
            MCThink(builder, "Хм. Теперь стало ясно (пасмурно), что для неё это не просто забава...");
            MCThink(builder, "Даже захотелось присоединиться к её приключению.");
            MCThink(builder, "Стоит предложить свою помощь");
            MCSay(builder, "Я тоже видел это объявление в интернете. Я подумал, что это розыгрыш" +
                " или что-то типа того...");

            builder.BeginSelector(string.Empty);

            builder.BeginSelectorVariant("\"Бред какой-то\"");
            builder.EndSelectorVariant(NonsenseLabel);

            builder.BeginSelectorVariant("Молчать (как Раян Гослинг)");
            builder.EndSelectorVariant(RyanGoslingLabel);

            builder.BeginSelectorVariant("Предложить помощь");
            builder.EndSelectorVariant(OfferHelpLabel);
            builder.EndSelector();

            builder.EndLabel();
            #endregion

            #region Nonsense
            builder.BeginLabel(NonsenseLabel);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "Впрочем, я не сильно-то и верю всему, что в интернете написано.");

            builder.EndGame("Супер плохая концовка - ГГ возвращается к старой жизни" +
                " (до этого была молодая) и живет в дисперсии");
            builder.EndLabel();
            #endregion

            #region RyanGosling
            builder.BeginLabel(RyanGoslingLabel);
            builder.Delay(1f);
            MCSay(builder, "... (как Раян Гослинг)");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, AnonSonyaName, "А не хочешь пойти со мной?");
            builder.Say(_sonya, AnonSonyaName, "Лишние руки мне не помешают.");
            builder.Jump(AdventureStartedLabel);
            builder.EndLabel();
            #endregion

            #region OfferHelp
            builder.BeginLabel(OfferHelpLabel);
            builder.ChangeVariable(_mc, _superGoodEndingVar, MathOperation.Add, 1);
            MCSay(builder, "Давай, я помогу тебе. Что думаешь?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(2f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Delay(1f);
            builder.Say(_sonya, AnonSonyaName, "Конечно! Буду рада твоей помощи.");
            builder.Jump(AdventureStartedLabel);
            builder.EndLabel();
            #endregion

            #region AdventureStarted
            builder.BeginLabel(AdventureStartedLabel);
            builder.ChangeBG(_street2BG);
            builder.Delay(1f);
            MCThink(builder, "По дороге мы разговорились.");
            MCThink(builder, "Оказалось, что девушку зовут Соня.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Move(_sonya, 0.3f);
            builder.Say(_sonya, "Я выросла в достаточно бедной семье.");
            builder.ChangeBG(_breadForPoorsBG);
            builder.Say(_sonya, "Помню времена, когда у нас дома из еды был только" +
                " черствый хлеб.");
            builder.ChangeBG(_breadForPurrsBG);
            builder.Say(_sonya, "Каждый раз, глотая его, я обещала сама себе, что в" +
            " будущем смогу заработать столько денег, что никогда больше не буду" +
            " испытывать голод.");
            builder.ChangeBG(_street2BG);
            builder.Say(_sonya, "Теперь у меня достаточно средств на жизнь, но страх всё еще" +
                " преследует меня.");
            builder.Say(_sonya, "Боюсь, что однажды тот день из детства повторится...");
            builder.Say(_sonya, "...что в холодильнике ничего не найдется...");
            builder.ChangeAppearance(_sonya, QueryMode.All, new TagSO[] { Fists }, new TagSO[] { Blush, Shy, Happy });
            builder.Say(_sonya, "Этот страх мотивирует меня на поиск сокровища!");
            builder.ChangeAppearance(_sonya, QueryMode.All, new TagSO[] { Fists, Happy }, new TagSO[] { Blush, Shy });
            builder.Say(_sonya, "Сокровища, которое принесёт мне много денег!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Sad);
            builder.Say(_sonya, "Тогда я буду уверена, что никогда не останусь без еды...");

            MCThink(builder, "Соня выглядит очень расстроенной...");

            builder.BeginSelector("Соня выглядит очень расстроенной");
            builder.BeginSelectorVariant("Обнять её");
            builder.EndSelectorVariant(HugSonyaLabel);

            builder.BeginSelectorVariant("Не расчетвёренной - и ладно...");
            builder.EndSelectorVariant(NotHugSonyaLabel);
            builder.EndSelector();
            builder.EndLabel();
            #endregion

            #region HugSonya
            builder.BeginLabel(HugSonyaLabel);
            builder.ChangeVariable(_mc, _superGoodEndingVar, MathOperation.Add, 1);
            builder.Hide(_sonya);
            MCSay(builder, "Я понимаю, как это неприятно, когда у тебя не хватает даже" +
                "самого нужного.");
            builder.ChangeBG(_sonyaAndMcHuggingBG);
            MCSay(builder, "Соня, мы с тобой вместе найдём это сокровище.");
            MCSay(builder, "И оно уберёт все твои страхи.");
            MCSay(builder, "Не волнуйся, я всегда буду рядом поддерживать тебя.");
            MCSay(builder, "И не важно, что нас ждёт на этом пути");
            builder.Jump(AdventureContinuedLabel);
            builder.EndLabel();
            #endregion

            #region NotHugSonya
            builder.BeginLabel(NotHugSonyaLabel);
            MCThink(builder, "Ну и шут с ней. Я тоже не прыгаю от счастья...");
            builder.Jump(AdventureContinuedLabel);
            builder.EndLabel();
            #endregion

            #region AdventureContinued
            builder.BeginLabel(AdventureContinuedLabel);
            builder.ChangeBG(_street2BG);
            MCThink(builder, "Мы продолжили своё путешествие по улицам, в поисках" +
                " начальной точки для наших исследований.");
            MCThink(builder, "Мы разговаривали о всяком разном...");
            MCThink(builder, "В какой-то момент разговор зашел о музыке. Я признался Соне," +
                " что раньше играл на гитаре, но всегда боялся выступать перед людьми.");
            MCThink(builder, "Всегда боялся, что мою игру осудят или посмеются надо мной...");
            builder.ChangeBG(_cursedOldHouseBG);
            builder.Delay(1f);
            builder.BeginSoundLoop(_rainSoundLoop);
            builder.ChangeBG(_cursedOldHouseRainBG);
            MCThink(builder, "Под конец дня начался сильный ливень.");
            MCThink(builder, "Мы шли по заросшему парку и увидели ветхий старый дом.");
            ShowNotNoodlesNotMap(builder, _sonya, 0.1f, Smile);
            builder.Say(_sonya, "Смотри! Мы можем переждать дождь в этом доме.");
            MCSay(builder, "Думаешь, там никто не живет?");
            builder.Say(_sonya, "Нет, конечно. У него же окна забиты.");
            MCSay(builder, "Ты права. К тому же, я ни разу не видел света за этими забитыми окнами." +
                " Там извечно царит мрак...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "Ты же не боишься всяких приведений и чудовищ?");

            builder.BeginSelector($"{_sonya.CharacterName}: Ты же не боишься всяких приведений и чудовищ?");
            builder.BeginSelectorVariant("\"Чудовищ нет на земле\"");
            builder.EndSelectorVariant(ThereAreNoMonstersOnEarthLabel);

            builder.BeginSelectorVariant("\"Боюсь\"");
            builder.EndSelectorVariant(ImAfraidOfMonstersLabel);

            builder.BeginSelectorVariant("\"...\"");
            builder.EndSelectorVariant(RyanMonsteringLabel);

            builder.EndSelector();
            builder.EndLabel();
            #endregion

            #region ThereAreNoMonstersOnEarth
            builder.BeginLabel(ThereAreNoMonstersOnEarthLabel);
            MCThink(builder, "Чудовищ нет на земле.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, IDunnoLol);
            builder.Say(_sonya, "А приведений?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Ладно, бежим, скорее, в дом, а то до нитки промокнем!");
            builder.Jump(AfterMonstersLabel);
            builder.EndLabel();
            #endregion

            #region ImAfraidOfMonsters
            builder.BeginLabel(ImAfraidOfMonstersLabel);
            MCThink(builder, "Ну боюсь...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(1.5f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Thinking);
            builder.Delay(1.5f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Бр-р-р!..");
            builder.Say(_sonya, "А я боюсь, что мы здесь замёрзнем!");
            MCThink(builder, "Cоня схватила меня за руку и затащила в дом.");
            builder.Jump(AfterMonstersLabel);
            builder.EndLabel();
            #endregion

            #region RyanMonstering
            builder.BeginLabel(RyanMonsteringLabel);
            MCThink(builder, "Я хотел сказать, что чудовищ не существует, но решил, что" +
                " это был риторический вопрос.");
            builder.Say(null, "Ужасный голос во мгле", "А-а-а-а-а!!!");
            MCSay(builder, "А-а-а-а-а-а!!!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "Что случилось?!");
            MCSay(builder, "Ничего, просто показалось, идём в дом.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, IDunnoLol);
            builder.Delay(1.2f);
            builder.Jump(AfterMonstersLabel);
            builder.EndLabel();
            #endregion

            #region AfterMonsters
            builder.BeginLabel(AfterMonstersLabel);
            builder.Hide(_sonya);
            builder.ChangeBG(_guitarInsideCursedOldHouseBG);
            builder.EndSoundLoop(_rainSoundLoop);
            MCThink(builder, "Изнутри этот дом выглядел ничем не лучше, чем снаружи.");
            MCThink(builder, "Впрочем, крыша есть - уже хорошо.");
            builder.BeginSoundLoop(_campfireSoundLoop);
            builder.Delay(1.4f);
            builder.ChangeBG(_campfireAndGuitarInsideCursedOldHouseBG);
            builder.Delay(0.6f);
            MCThink(builder, "Мы разожгли костер, чтобы согреться.");
            ShowNotNoodlesNotMap(builder, _sonya, 0.3f, Neutral);
            builder.Say(_sonya, "Ты куришь?");
            MCSay(builder, "Нет. Курить - здоровью вредить!");
            builder.Say(_sonya, "Понятно...");
            builder.Delay(1.4f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "Погоди, а зачем тогда тебе зажигалка?");
            MCThink(builder, "5 лет назад меня избили гопники по причине \"закурить не нашлось\".");
            MCThink(builder, "С тех пор я не выхожу из дома без зажигалки...");
            MCThink(builder, "...");
            MCThink(builder, "Наверное, это будет сложно объяснить Соне...");

            builder.BeginSelector("Соня спросила, зачем мне зажигалка");
            builder.BeginSelectorVariant("Кнопки в лифте жгу");
            builder.EndSelectorVariant(ElevatorArsonistLabel);
            builder.BeginSelectorVariant("Я фокусник");
            builder.EndSelectorVariant(MagicianLabel);
            builder.EndLabel();
            #endregion

            #region ElevatorArsonist
            FillElevatorArsonist(builder, ElevatorArsonistLabel, AfterCampfireLabel);
            #endregion

            FillAfterCampfire(builder, AfterCampfireLabel);

            return builder.Build();
        }

        private void FillAfterCampfire(NovelScriptBuilder builder, string labelName)
        {
            const string AnswerTruly = "AfterCampfire_AnswerTruly";
            const string Lie = "AfterCampfire_Lie";
            const string Guitar = "AfterCampfire_Guitar";

            #region AfterCampfire
            builder.BeginLabel(labelName);
            builder.ChangeBG(_campfireAndGuitarInsideCursedOldHouseBG);
            builder.Delay(0.3f);
            MCThink(builder, "Бесконечно можно смотреть на 3 вещи:");
            MCThink(builder, "Как горит огонь..");
            MCThink(builder, "Как течет вода..");
            MCThink(builder, "И на то, как кто-то работает..");
            MCThink(builder, "...");
            MCThink(builder, "Желательно, не ты сам.");
            MCThink(builder, "...");
            MCThink(builder, "Соня уже уснула?");
            MCThink(builder, "Сидя?");
            MCSay(builder, "Сонь, ты спишь?");
            ShowNotNoodlesNotMap(builder, _sonya, 0.75f, Huh);
            builder.Delay(0.8f);
            builder.Say(_sonya, "Ты издеваешься? Я же с тобой разговариваю.");
            MCThink(builder, "?");
            MCThink(builder, "Серьезно?");
            MCThink(builder, "Кажется, я всё прослушал...");
            MCSay(builder, "Сонь, ты спишь?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Думаешь сейчас, наверно, типа \"О, нет... Я только-только встретил симпатичную" +
                "девушку, и вот мы в проклятом старом доме... одни...\"");
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Sad);
            builder.Say(_sonya, "\"...а я уже умудрился пропустить мимо ушей её признание...\"");
            MCThink(builder, "!?");
            MCThink(builder, "Честный ответ, обычно, самый лучший.");
            MCThink(builder, "Но в такой ситуации нужно полагаться не на честность, а на смекалку.");
            MCThink(builder, "...");
            MCThink(builder, "Что же делать?..");
            builder.Selector("Кажется, я прослушал какое-то признание...",
                ("Сказать правду", AnswerTruly), ("Солгать", Lie));
            builder.EndLabel();
            #endregion

            FillAnswerTruly(builder, AnswerTruly, Guitar);
            FillLie(builder, Lie, Guitar);

            FillGuitar(builder, Guitar);
        }

        private void FillGuitar(NovelScriptBuilder builder, string labelName)
        {
            const string Bac = "AfterCampfire_Guitar_Bac";
            const string NotBac = "AfterCampfire_Guitar_NotBac";
            const string Sleep = "AfterCampfire_Guitar_NotBac";

            builder.BeginLabel(labelName);
            builder.Delay(1f);
            MCThink(builder, "А Соня всё смотрит на огонь...");
            MCThink(builder, "Ну, а на что еще здесь смотреть?");
            MCThink(builder, "...");
            builder.Hide(_sonya);
            MCThink(builder, "Как же здесь много мусора..");
            MCThink(builder, "Настоящая свалка.");
            MCThink(builder, "...");
            MCThink(builder, "А это что?");
            MCThink(builder, "Ого, санкционная Кека Кола!");
            MCThink(builder, "А, нет, просто \"Красная Цена\"...");
            MCThink(builder, "...");
            MCThink(builder, "А это?");
            MCThink(builder, "Да это же...");
            MCThink(builder, "Гитара?");
            MCThink(builder, "Что она делает среди всего этого мусора?!");
            MCThink(builder, "...");
            builder.ChangeBG(_campfireInsideCursedOldHouseBG);
            builder.Delay(1f);
            MCThink(builder, "А, это Старсан.");
            MCThink(builder, "Надо быстрее её выбросить, пока никто не увидел...");
            ShowNotNoodlesNotMap(builder, _sonya, 0.5f, Smile);
            builder.Delay(0.3f);
            builder.Say(_sonya, "Ага! Зашкварился!");
            MCSay(builder, "ДА ЭТО НЕ!..");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            MCSay(builder, "Это не то, на что...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            MCSay(builder, "Да мне её крысы подкинули!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Ихи-хи-хи-хи");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Ну, сбацай тогда-уж что-нибудь.");
            MCSay(builder, "Да на этом [инструменте] только Зеленого Слоница бацать...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Ну, его и сбацай.");
            builder.Selector("Соня хочет, чтобы я сыграл на гитаре",
                ("Сбацать Зеленого Слоника", Bac), ("Солгать, что гитара разрядилась", NotBac));
            builder.EndLabel();

            FillGuitarBac(builder, Bac, Sleep);
            FillGuitarNotBac(builder, NotBac, Sleep);

            FillSleep(builder, Sleep);
        }

        private void FillSleep(NovelScriptBuilder builder, string labelName)
        {
            builder.BeginLabel(labelName);
            builder.Hide(_sonya);
            builder.ChangeBG(_blackScreenBG);
            builder.Say(null, "повествование", "Ночь прошла спокойно...");
            builder.Say(null, "повествование", "Но вот на утро...");
            builder.Say(_sonya, "Вставай");
            builder.Say(_sonya, "Вставай скорее!");
            builder.Say(_sonya, "ВСТАВАЙ!!!");
            builder.ChangeBG(_campfireInsideCursedOldHouseBG);
            ShowNotNoodlesNotMap(builder, _sonya, 0.6f, Huh);
            MCSay(builder, "А?");
            MCSay(builder, "Что?");
            MCSay(builder, "Где?");
            ShowNotNoodlesNotMap(builder, _sonya, 0.6f, Huh);
            builder.Say(_sonya, "СОКРОВИЩА!!!");
            ShowNotNoodlesNotMap(builder, _sonya, 0.6f, Huh);
            MCSay(builder, "???");
            MCSay(builder, "Почему утром так темно?");
            ShowNotNoodlesNotMap(builder, _sonya, 0.6f, Huh);
            builder.Say(_sonya, "Мы не успели нарисовать новые фоны, неважно...");
            builder.Say(_sonya, "БЫСТРЕЕ ВСТАВАЙ!!");
            builder.ChangeBG(_blackScreenBG);
            builder.Say(null, "повествование", "Соня потащила нашего героя к какой-то двери.");
            ShowNotNoodlesNotMap(builder, _sonya, 0.6f, Vahui);
            builder.Say(_sonya, "Помоги мне выбить её!");
            builder.Say(null, "повествование", "Совместными усилиями и парой вывихнутых плечевых суставов, наши" +
                " герои справились с этим деревянным противником.");
            builder.Say(null, "повествование", "А за ним...");
            builder.ChangeBG(_treasures);
            ShowNotNoodlesNotMap(builder, _sonya, 0.6f, Happy);
            builder.Say(_sonya, "...");
            MCSay(builder, "...");
            builder.Say(_sonya, "Что смотришь, хватай быстрее, пока джем не закончился!");
            MCSay(builder, "А, да, точно!");
            builder.EndGame("Наши герои нашли сокровище, самая лучшая концовка!!!");
        }

        private void FillGuitarBac(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            builder.BeginLabel(labelName);
            MCThink(builder, "Долгие годы тренировок...");
            MCThink(builder, "Прошли даром.");
            MCThink(builder, "(Вздох)");
            MCThink(builder, "Э, а че это я только думаю о вздохе?!");
            MCSay(builder, "(Вздох)");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Blush);
            builder.Say(_sonya, "Можно я подпевать буду?");
            MCSay(builder, "Можно!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Blush);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Ура-а-а!!!");
            builder.Say(null, "повествование", "Проклятый старый дом озарила яркая вспышка...");
            builder.Say(null, "повествование", "В гитаре была противопехотная мина.");
            builder.Say(null, "повествование", ".");
            builder.Say(null, "повествование", "..");
            builder.Say(null, "повествование", "...");
            builder.Say(null, "повествование", "Ладно, это был мой разрывной сценарий.");
            builder.Say(null, "повествование", "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(null, "повествование", "Лицо Сони озарила улыбка");
            builder.Say(null, "повествование", "А по комнате полилась приятная музыка");
            builder.Say(null, "повествование", "Которую нам, конечно же, не написали.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            MCSay(builder, "Пам. Па-па-па-па-па-пам.");
            MCSay(builder, "Па-па-па-па-па-пам");
            MCSay(builder, "Па-па-па-па-па-па-па-па!");

            MCSay(builder, "Па-па-па-па-па-пам.");
            MCSay(builder, "Па-па-па-па-па-пам.");
            MCSay(builder, "Па-па-па-па-па-па-па-па!");

            builder.Say(_sonya, "Зелёный слоник в наш оркестр пришёл!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Зелёный слоник нам трубу принёс!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Когда ребята уходили,");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Зелёный слоник на трубе игр...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(null, "Китайская гитара StarSun", "Дзлинг!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(null, "Китайская гитара StarSun", "(струна порвалась)");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Sad);
            builder.Say(_sonya, "...ал.");
            builder.Say(_sonya, "...");
            MCSay(builder, "...");
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Sad);
            MCSay(builder, "Вот, зеленый слоник, видимо, и наигрался.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Я отлично провела время, даже не смотря на эту струну.");
            MCSay(builder, "Так и не смотри...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "Скоро даже при желании не смогу.");
            MCSay(builder, "?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Sad);
            builder.Say(_sonya, "Костер вот-вот потухнет.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Sad);
            builder.Say(_sonya, "Мы замерзнем и умрем.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Без паники!");
            builder.Say(null, "повествование", "Гитара полетела в костер");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Второй раз уже она спасает наш день!");
            MCSay(builder, "Это точно...");
            MCSay(builder, "Ладно, пора спать, а то сценарий дописать не успеем.");
            builder.Say(_sonya, "Да! 15 минут осталось!");
            builder.Jump(nextLabelName);
            builder.EndLabel();
        }

        private void FillGuitarNotBac(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            builder.BeginLabel(labelName);
            MCThink(builder, "Нет, она явно заслуживает большего...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCThink(builder, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Ох, я бы сыграл, да вот... только...");
            MCSay(builder, "Она...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "Да, она полностью разряжена.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "Кто разряжена?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "Аккустическая гитара?");
            MCSay(builder, "О-о-о, не-е-ет...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Это новейшие и хитрейшие технологии китайского гитаростроения...");
            MCSay(builder, "А это их недавняя модель - NeeXiao2000");
            MCSay(builder, "Как видишь - струны не светятся...");
            MCSay(builder, "Значит, у этой гитарый сел аккумулятор...");
            MCThink(builder, "...в тюрьму.");
            builder.Say(_sonya, "Да ладно? Дай-ка, я посмотрю...");
            MCThink(builder, "Ни... за... что...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Что это?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "БЕРЕГИСЬ, СОНЯ!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "ЭТО КРЫСА-МУТАНТ!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "Я СПАСУ ТЕБЯ!");
            builder.Say(null, "Гитара StarSun", "Ай!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(null, "Гитара StarSun", "Ой!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(null, "Гитара StarSun", "(Умерла)");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "Всё, Соня, я тебя спас!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Blush);
            builder.Delay(0.7f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Мой герой~");
            MCSay(builder, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "А?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Пора на боковую...");
            builder.Jump(nextLabelName);
            builder.EndLabel();
        }

        private void FillLie(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            builder.BeginLabel(labelName);
            MCSay(builder, "Ничего я...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "Ох, не надо оправдываться...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, "...");
            MCSay(builder, "Нет, подруга, я не оправдываюсь...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Просто я реально слышал и слушал каждое твоё слово.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(1f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "И о чем я тогда говорила?");
            MCSay(builder, "Да о бабских своих проблемах всяких.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "...");
            MCSay(builder, "О платьях, мужиках, модах всяких.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            MCSay(builder, "Вот.");
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "Блин, а ты...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "Внимательный!");
            MCSay(builder, "Ну, этого не отнять...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Кстати, я всё это время молчала.");
            MCSay(builder, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Просто решила тебя подколоть");
            MCThink(builder, "...");
            MCThink(builder, "Я это запомню...");
            builder.Say(null, "Подсознание", "Вы это забыли");
            builder.Jump(nextLabelName);
            builder.EndLabel();
        }

        private void FillAnswerTruly(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            const string Unitaz = "AfterCampfire_AnswerTruly_Unitaz";
            const string Gaming = "AfterCampfire_AnswerTruly_Gaming";
            const string Comic = "AfterCampfire_AnswerTruly_Comic";

            builder.BeginLabel(labelName);

            MCThink(builder, "Ложь порождает лишь бо́льшую ложь...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, "(Вздох)");
            builder.Selector("...",
               ("Я промахнулся мимо унитаза", Unitaz),
               ("Я прячу свою тонкую душевную организацию под маской комика", Comic),
               ("Я играю на работе", Gaming));
            builder.EndLabel();

            FillUnitaz(builder, Unitaz, nextLabelName);
            FillGaming(builder, Gaming, nextLabelName);
            FillComic(builder, Comic, nextLabelName);
        }

        private void FillComic(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            builder.BeginLabel(labelName);
            MCSay(builder, "Я...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, ".");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "..");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "Ты?..");
            MCSay(builder, "...");
            MCThink(builder, "Нет, слишком сложно.");
            MCSay(builder, "Я..годицы у тебя что надо (klass.png)");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Delay(1f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(1f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(1f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Спасибо, приятно слышать!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "А у тебя - классный подбородок.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "Оба.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            MCSay(builder, "Спасибо, стараюсь!");
            builder.Jump(nextLabelName);
            builder.EndLabel();
        }

        private void FillGaming(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            builder.BeginLabel(labelName);
            MCSay(builder, "Я...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, "...");
            MCSay(builder, "Играю в компутер на работе.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "...");
            MCSay(builder, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "О..кей?..");
            builder.Say(_sonya, "И во что же ты играешь на работе?");
            MCSay(builder, "В пасьянса Человека-Паука.");
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Да это-ж круто!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Научишь как-нибудь потом?");
            MCSay(builder, "Обязательно!");
            MCSay(builder, "Приходи ко мне на работу в следующую среду.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Замётано!");
            builder.Jump(nextLabelName);
            builder.EndLabel();
        }

        private void FillUnitaz(NovelScriptBuilder builder, string labelName, string nextLabelName)
        {
            builder.BeginLabel(labelName);
            MCSay(builder, "В детстве я промахнулся мимо унитаза.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Delay(3f);
            MCSay(builder, "...");
            builder.Say(_sonya, "...");
            MCSay(builder, "Промахнулся на 100 метров.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Delay(1f);
            MCSay(builder, "Это мой путь ниндзя.");
            builder.Say(_sonya, "Мы можем считать, что этого разговора не было?");
            MCSay(builder, "Мы не калькуляторы, чтобы считать.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "Хорошо...");
            MCSay(builder, "Прекрасно.");
            MCSay(builder, "Восхитительно.");
            builder.Jump(nextLabelName);
            builder.EndLabel();
        }

        private void FillElevatorArsonist(NovelScriptBuilder builder,
            string elevatorArsonistLabel, string nextLabel)
        {
            const string BotvaLabel = "Botva";
            const string ThroughTheWindowLabel = "ThroughTheWindow";
            const string MyDreamsLabel = "MyDreams";
            const string WhyLighterAfterElevatorContinueLabel = "WhyLighterAfterElevatorContinue";
            const string WhyLighterAfterElevatorAfterNsfwFinalLabel = "WhyLighterAfterElevatorAfterNsfwFinal";

            builder.BeginLabel(elevatorArsonistLabel);
            MCSay(builder, "Моя жизнь весьма однообразна");
            MCSay(builder, "5 дней в неделю я хожу на работу, а потом 2 дня валяюсь на диване и смотрю...");

            builder.Selector("а че я смотрю-то?..",
                ("...Ботву Экстрасенсов", BotvaLabel),
                ("...в окно", ThroughTheWindowLabel),
                ("...свои сны", MyDreamsLabel));

            builder.EndLabel();

            FillBotva(builder, BotvaLabel, WhyLighterAfterElevatorContinueLabel);


            builder.BeginLabel(ThroughTheWindowLabel);
            MCSay(builder, "В окно я, в общем-то, смотрю и думаю постоянно: \"почему бы не купить зажигалку?\"");
            MCSay(builder, "Ну и купил, вот.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Ну, понятно.");
            builder.Say(_sonya, "Гигант мысли, получается?");
            MCSay(builder, "Получается.");
            MCThink(builder, "Фуф, пронесло...");
            builder.Jump(nextLabel);
            builder.EndLabel();


            builder.BeginLabel(MyDreamsLabel);
            MCSay(builder, "...сны свои смотрю. У меня нет ни кровати, ни телевизора, а тогда - даже зажигалки не было.");
            MCSay(builder, "Ну и купил, вот.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "Ну, понятно.");
            MCThink(builder, "Странно получилось, конечно, но...");
            MCThink(builder, "...");
            MCThink(builder, "...вроде, прокатило...");
            builder.Jump(nextLabel);
            builder.EndLabel();


            builder.BeginLabel(WhyLighterAfterElevatorContinueLabel);
            MCSay(builder, "Возвращаясь к теме зажигалки...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, "В общем, я еще с детства хотел себе автомобиль.");
            MCSay(builder, "Но с этим постоянно были какие-то проблемы.");
            MCSay(builder, "То права нельзя получить в 13 лет...");
            MCSay(builder, "То нет денег на автошколу...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, "То нет денег на сам автомобиль...");
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Если мы... нет.");
            builder.Say(_sonya, "КОГДА мы найдём сокровище...");
            builder.Say(_sonya, "Мы оба сможем исполнить свои мечты!");
            builder.Say(_sonya, "Я смогу купить себе сухпайков на 100 лет вперёд, а ты...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Ты купишь себе автомобиль, который всегда хотел!");
            MCSay(builder, "...");
            MCSay(builder, "А?");
            MCSay(builder, "Нет.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(1f);
            MCSay(builder, "Нет, сейчас-то у меня есть деньги на автомобиль - проблема в другом.");
            MCSay(builder, "Видишь ли, как я и говорил, я 5 дней в неделю - работаю на работе, в офисе," +
                " буквально через дорогу от моего дома.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            MCSay(builder, "А оставшиеся 2 дня выходных я, собственно, не выхожу никуда - нет ни сил, ни желания.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "А");
            builder.StartNsfwMiniGame(WhyLighterAfterElevatorAfterNsfwFinalLabel);
            builder.EndLabel();


            builder.BeginLabel(WhyLighterAfterElevatorAfterNsfwFinalLabel);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "Так и зачем же тебе зажигалка?");
            MCSay(builder, "Хоть кататься на автомобиле мне некуда, на лифте я катаюсь каждый день.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "...");
            MCSay(builder, "С первого этажа до 25, а потом обратно, а потом на другое обратно...");
            MCSay(builder, "И так, пока все кнопки не расплавлю.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Say(_sonya, "...");
            MCSay(builder, "Зажигалкой-то.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Thinking);
            builder.Say(_sonya, ".");
            builder.Say(_sonya, "..");
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Say(_sonya, "Ладно.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Повезло, получается.");
            builder.Jump(nextLabel);
            builder.EndLabel();
        }

        private void FillBotva(NovelScriptBuilder builder, string botvaLabel, string nextLabel)
        {
            const string HardChallengeYes = "BotvaLastEpisopeHardChallengeWithMachinesYes";
            const string HardChallengeNo = "BotvaLastEpisopeHardChallengeWithMachinesNo";
            const string HardChallengeSecretWeapon = "BotvaLastEpisopeHardChallengeWithMachinesSecretWeapon";
            const string LeaveAfterYes = "BotvaLastEpisodeLeaveAfterYes";
            const string FailAfterYes = "BotvaLastEpisodeFailAfterYes";
            const string SecretWeaponAfterYes = "BotvaLastEpisodeSecretWeaponAfterYes";

            const string SecretWeaponAfterYes_HaveSecretWeapon = "BotvaSecretWeaponAfterYes_HaveSecretWeapon";
            const string SecretWeaponAfterYes_HaveNotSecretWeapon = "BotvaSecretWeaponAfterYes_HaveNotSecretWeapon";
            const string RegainLostTrustLabel = "BotvaRegainLostTrust";

            const string HardChallengeSecretWeapon_Have = "HardChallengeSecretWeapon_Have";
            const string HardChallengeSecretWeapon_HaveNot = "HardChallengeSecretWeapon_HaveNot";

            #region Init
            builder.BeginLabel(botvaLabel);
            MCSay(builder, "..Ботву Экстрасенсов...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Delay(1.4f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Ого, ты тоже её смотришь?");
            MCThink(builder, "Вообще-то, нет...");
            MCThink(builder, "Но, в любом случае, надо попытаться поддержать разговор, иначе" +
                " придётся использовать секретное оружие...");
            MCThink(builder, "Да, есть немного...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "В последней серии такое жесткое испытание было с машинами, скажи??");

            builder.Selector("...жесткое испытание с машинами?..",
                ("Да, жестко было!", HardChallengeYes),
                ("Пф-ф-ф... бывало и пожестче", HardChallengeNo),
                ("[Использовать секретное оружие]", HardChallengeSecretWeapon));
            builder.EndLabel();
            #endregion

            #region Yes
            builder.BeginLabel(HardChallengeYes);
            MCSay(builder, "Да-а-а, реальный жестяк, так сказать, был! Ваще...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "А какая машина тебе больше всего понравилась?");
            builder.Selector("Какая машина больше всего понравилась?",
                ("Стиральная", LeaveAfterYes),
                ("Мерседес", LeaveAfterYes),
                ("Электронная вычислительная", FailAfterYes),
                ("[Использовать секретное оружие]", SecretWeaponAfterYes));
            builder.EndLabel();

            builder.BeginLabel(LeaveAfterYes);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, IDunnoLol);
            builder.Delay(0.4f);
            builder.Say(_sonya, "Да? А мне - швейная.");
            MCSay(builder, "Ну, как говорится - \"на вкус и цвет...\"");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "...все фломастеры разные.");
            MCThink(builder, "О, как.");
            builder.Jump(nextLabel);
            builder.EndLabel();

            builder.BeginLabel(FailAfterYes);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Thinking);
            builder.Say(_sonya, "...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "Не было там электронной вычислительной машины никакой!");
            MCThink(builder, "Блин, не угадал...");
            builder.Say(_sonya, "Нормально ты мне наплёл с 3 короба...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Neutral);
            builder.Delay(2f);
            builder.Say(_sonya, "И как тебе доверять после этого...");
            MCThink(builder, "...");
            MCThink(builder, "Что делать?..");
            //сдаться или восстановить доверие Сони с помощью мини-игры
            builder.Selector("Что делать?",
                ("Ничего...", nextLabel),
                ("Вернуть утраченное доверие", RegainLostTrustLabel));
            builder.EndLabel();

            FillRegainLostTrust(builder, RegainLostTrustLabel, nextLabel);

            #region Secret
            builder.BeginLabel(SecretWeaponAfterYes);
            FillSecretWeaponBranch(builder, SecretWeaponAfterYes_HaveSecretWeapon,
                SecretWeaponAfterYes_HaveNotSecretWeapon);
            builder.EndLabel();

            #region Have
            builder.BeginLabel(SecretWeaponAfterYes_HaveSecretWeapon);
            builder.ChangeVariable(_mc, _secretWeaponUsedVar, MathOperation.Add, 1);
            MCSay(builder, "Мне в той серии ВООБЩЕ ВСЁ понравилось!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "Каждая машина - просто ВЫСШИЙ КЛАСС!");
            MCSay(builder, "И испытания - огонь, вообще!");
            MCSay(builder, "Особенно мне то, где тот мужик руками водил, понравилось.");
            MCSay(builder, "Но выше всех похвал - тот момент...");
            MCSay(builder, "Понимаешь, о каком я?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Happy);
            builder.Say(_sonya, "Понимаю, но ты всё равно скажи!");
            MCSay(builder, "Я о том моменте, когда...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            MCSay(builder, "...тому парню в шапке завязали глаза, а потом отправили его в другую комнату...");
            MCSay(builder, "...и там его попросили отгадать код от сейфа...");
            MCSay(builder, "...и вот он, перед сейфом встал...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            MCSay(builder, "...стоит...");
            MCSay(builder, "...а потом КА-А-АК закричит!");
            builder.Say(_sonya, "А-а-а!!!");
            MCSay(builder, "Да, примерно так.");
            builder.Say(_sonya, "А что потом?");
            MCSay(builder, "А потом он бьёт ладонью по полу, перед сейфом...");
            builder.Say(_sonya, "Та-а-ак. А дальше??");
            MCSay(builder, "И сразу после удара...");
            MCSay(builder, "...");
            builder.Say(_sonya, "...");
            MCSay(builder, "...сейф ОТКРЫВАЕТСЯ!");
            MCSay(builder, "А там...");
            builder.Say(_sonya, "???");
            builder.ChangeAppearance(_sonya, Noodles, Smile);
            MCSay(builder, "Лапша, которую я тебе на уши вешаю.");
            builder.Say(null, "Секретное оружие", "Миссия выполнена.");
            MCThink(builder, "Я потратил своё единственное секретное оружие.");
            MCThink(builder, "Теперь придется подходить к выборам с бо́льшей ответственностью.");
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "А?");
            builder.Say(_sonya, "Ой, извини, что-то я из темы выпала...");
            builder.Say(_sonya, "На чем мы остановились?");
            MCSay(builder, "Мы хотели погреться у костра.");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "А, точно!");
            builder.Jump(nextLabel);
            builder.EndLabel();
            #endregion

            #region havent
            builder.BeginLabel(SecretWeaponAfterYes_HaveNotSecretWeapon);
            MCThink(builder, "Вот чёрт! Я же уже использовал своё секретное оружие!");
            MCThink(builder, "Что делать, что делать?..");
            MCThink(builder, ".");
            MCThink(builder, "..");
            MCThink(builder, "...");
            MCThink(builder, "!");
            MCThink(builder, "Придумал! Расскажу анекдот!");
            MCSay(builder, "Внимание! Анекдот!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(0.75f);
            MCSay(builder, "Из чего состоит романтический коктейль \"69\"?");
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "э-э-э... из чего?..");
            MCSay(builder, "Из Балтики 9...");
            MCSay(builder, "... и Балтики 6!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Delay(3f);
            builder.Say(_sonya, "Но по правилам джема нельзя использовать 18+ контент!");
            MCSay(builder, "...");
            MCSay(builder, "А обе Балтики - безалкогольные!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(0.8f);
            builder.Say(_sonya, "А ловко ты придумал! Молодец!");
            builder.Say(null, "Отголоски секретного оружия", "Остатки лапши всё еще висят на" +
                "ушах Сони. Именно из-за них, она не заметила ошибку в анекдоте.");
            builder.Jump(nextLabel);
            builder.EndLabel();
            #endregion

            #endregion

            #endregion

            #region No
            builder.BeginLabel(HardChallengeNo);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, IDunnoLol);
            builder.Say(_sonya, "Да, действительно, ничего особенного.");
            builder.Jump(nextLabel);
            builder.EndLabel();
            #endregion

            #region SecretWeapon
            builder.BeginLabel(HardChallengeSecretWeapon);
            FillSecretWeaponBranch(builder, HardChallengeSecretWeapon_Have,
                HardChallengeSecretWeapon_HaveNot);
            builder.EndLabel();


            builder.BeginLabel(HardChallengeSecretWeapon_Have);
            builder.ChangeVariable(_mc, _secretWeaponUsedVar, MathOperation.Add, 1);
            builder.Say(null, "Секретное оружие", "Пс-с-с!");
            MCSay(builder, "А!? Кто здесь!?");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Vahui);
            builder.Say(_sonya, "В смысле \"кто здесь\"? Я здесь!");
            builder.Say(null, "Секретное оружие", "Тихо! Только ты меня слышишь, дебил!");
            builder.Say(null, "Секретное оружие", "Ты можешь общаться со мной мысленно -" +
                " вслух мне ничего говорить не надо, усек?");
            MCThink(builder, "Усёк...");
            builder.Say(null, "Секретное оружие", "Вот и замечательно.");
            builder.Say(null, "Секретное оружие", "Значит так, я не собираюсь с тобой \"сюсюкаться\".");
            builder.Say(null, "Секретное оружие", "Сейчас я дам тебе инструкцию, как выбраться из твоей ситуации.");
            MCThink(builder, "Х-хорошо...");
            builder.Say(null, "Секретное оружие", "Найди работу.");
            MCThink(builder, "...");
            MCThink(builder, "?..");
            MCThink(builder, "??.");
            MCThink(builder, "???");
            MCThink(builder, "Но у меня уже есть работа!");
            builder.Say(null, "Секретное оружие", "Что?");
            builder.Say(null, "Секретное оружие", "А, это не тебе.");
            MCThink(builder, "А кому?");
            builder.Say(null, "Секретное оружие", "Тому челу по ту сторону экрана.");
            builder.Say(null, "Секретное оружие", "А что касается ТЕБЯ...");
            builder.Say(null, "Секретное оружие", "Когда тебя спросят про машины - сначала отвечай" +
                " \"да\", а потом - \"стиральная\".");
            builder.Say(null, "Секретное оружие", "Всё понял?");
            builder.Say(null, "Секретное оружие", "Можешь не отвечать, я тебя запускаю.");
            MCThink(builder, "Что? Куда!?");
            builder.Say(null, "Секретное оружие", "В прошлое...");
            builder.Jump(botvaLabel);
            builder.EndLabel();

            builder.BeginLabel(HardChallengeSecretWeapon_HaveNot);
            builder.Say(null, "Секретное оружие", "Помогаю только раз, тот еще я... - рифму придумаешь сам!");
            builder.Say(null, "Секретное оружие", "Пока!");
            builder.Jump(botvaLabel);
            builder.EndLabel();
            #endregion
        }

        private void FillRegainLostTrust(NovelScriptBuilder builder, string labelName, string nextLabel)
        {
            // мини-игра, где нужно ловить доверие и уворачиваться от недоверия.

            builder.BeginLabel(labelName);
            MCSay(builder, "Доверять мне - очень просто.");
            MCSay(builder, "Берешь...");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Thinking);
            builder.Delay(1f);
            MCSay(builder, "...и доверяешь!");
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Huh);
            builder.Delay(2f);
            ChangeAppearanceNotNoodlesNotMap(builder, _sonya, Smile);
            builder.Say(_sonya, "Спасибо за инструкцию! Буду пользоваться!");
            builder.Jump(nextLabel);
            builder.EndLabel();

            //throw new System.NotImplementedException();
        }

        private void MCThink(NovelScriptBuilder builder, string text)
        {
            builder.Think(text);
        }

        private void MCSay(NovelScriptBuilder builder, string text)
        {
            builder.Say(_mc, text);
        }

        private void FillSecretWeaponBranch(NovelScriptBuilder builder,
            string haveWeaponDestination, string haveNotWeaponDestination)
        {
            builder.BeginAutoBranch();
            builder.BeginConditionBlock(new VariableCondition<int>()
            {
                Character = _mc,
                Variable = _secretWeaponUsedVar,
                Equation = MathEquation.AreEqual,
                Value = 0
            });
            builder.EndConditionBlock(haveWeaponDestination);

            builder.BeginConditionBlock(new VariableCondition<int>()
            {
                Character = _mc,
                Variable = _secretWeaponUsedVar,
                Equation = MathEquation.AreNotEqual,
                Value = 0
            });
            builder.EndConditionBlock(haveNotWeaponDestination);
        }

        private void ChangeAppearanceNotNoodlesNotMap(NovelScriptBuilder builder, Character character, params TagSO[] tags)
        {
            builder.ChangeAppearance(character, QueryMode.All, (IEnumerable<TagSO>)tags, _noodleMapTagQuery);
        }

        private void ShowNotNoodlesNotMap(NovelScriptBuilder builder, Character character, float position, params TagSO[] tags)
        {
            builder.Show(character, position, QueryMode.All, (IEnumerable<TagSO>)tags, _noodleMapTagQuery);
        }
    }
}
