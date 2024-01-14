using DevourDev.Unity.NovelEngine.Builders.BaseBuilder;
using DevourDev.Unity.NovelEngine.Builders.Entities;
using DevourDev.Unity.NovelEngine.Builders.Interfaces;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;
using NovelEngine.Entities;
using NovelEngine.Entities.Interface;
using UnityEditor.PackageManager;
using UnityEngine;

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
        [SerializeField] private AppearanceKey _smilingAppKey;
        [SerializeField] private AppearanceKey _thinkingAppKey;
        [SerializeField] private AppearanceKey _lookingAtTheMapAppKey;
        [SerializeField] private AppearanceKey _neutralFaceAppKey;
        [SerializeField] private AppearanceKey _vahuiAppKey;
        [SerializeField] private AppearanceKey _idkLolAppKey;
        [SerializeField] private AppearanceKey _superHappyAppKey;
        [SerializeField] private AppearanceKey _huhStarringAppKey;
        [SerializeField] private AppearanceKey _upsetAppKey;
        [SerializeField] private AppearanceKey _noodlesOnEarsAppKey;

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
        [SerializeField] private BackGround _sonyaAndMcHuggingBG;
        [SerializeField] private BackGround _sonyaAndMcHugging2BG;
        [SerializeField] private BackGround _cursedOldHouseBG;
        [SerializeField] private BackGround _cursedOldHouseRainBG;
        [SerializeField] private BackGround _insideCursedOldHouseBG;
        [SerializeField] private BackGround _campfireInsideCursedOldHouseBG;


        public override NovelScriptData Build()
        {
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
            MCThink(builder, "Я провожу еще один день, сложно оказавшись в замкнутом круге.");
            MCThink(builder, "Просыпаюсь каждое утро с мыслью, что сегодня будет точная копия" +
                " вчерашнего дня: работа, дом.");
            MCThink(builder, "А потом снова и снова, словно день сурка.");
            MCThink(builder, "Всё вокруг меня кажется одинаковым и неинтересным.");
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
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Move(_sonya, 0.5f);
            builder.Say(_sonya, AnonSonyaName, "Привет!");
            builder.Say(_sonya, AnonSonyaName, "Я ищу сокровище.");
            builder.Say(_sonya, AnonSonyaName, "Звучит, наверное, странно...");
            builder.PlaySound(_femaleLaughter);
            builder.Say(_sonya, AnonSonyaName, "*женский смех*");
            //builder.Delay(1f);
            builder.Say(_sonya, AnonSonyaName, "Эта карта...");
            builder.Say(_sonya, AnonSonyaName, "Она указывает на местоположение сокровища.");
            builder.ChangeAppearance(_sonya, _neutralFaceAppKey);
            builder.Say(_sonya, AnonSonyaName, "Веришь в такое?");
            MCThink(builder, "Странная она какая-то...");
            MCThink(builder, "Но в глазах видно искры азарта и жажды приключений.");
            MCSay(builder, "Да, я думаю, можно поверить в такие вещи");
            MCSay(builder, "Но как ты узнала о существовании этой карты и что именно ты хочешь найти?");
            builder.ChangeAppearance(_sonya, _thinkingAppKey);
            builder.Delay(1.5f);
            builder.ChangeAppearance(_sonya, _lookingAtTheMapAppKey);
            builder.Delay(2f);
            builder.ChangeAppearance(_sonya, _idkLolAppKey);
            builder.Say(_sonya, AnonSonyaName, "Увидела объявление в интернете.");
            builder.Say(_sonya, AnonSonyaName, "А живу я не особо богато, поэтому решила, что это мой шанс " +
                @"¯\_(ツ)_/¯");
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
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
            MCSay(builder, "Впрочем, я не сильно-то и верю всему, что в интернете написано.");

            builder.EndGame("Супер плохая концовка - ГГ возвращается к старой жизни" +
                " (до этого была молодая) и живет в дисперсии");
            builder.EndLabel();
            #endregion

            #region RyanGosling
            builder.BeginLabel(RyanGoslingLabel);
            builder.Delay(1f);
            MCSay(builder, "... (как Раян Гослинг)");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, AnonSonyaName, "А не хочешь пойти со мной?");
            builder.Say(_sonya, AnonSonyaName, "Лишние руки мне не помешают.");
            builder.Jump(AdventureStartedLabel);
            builder.EndLabel();
            #endregion

            #region OfferHelp
            builder.BeginLabel(OfferHelpLabel);
            builder.ChangeVariable(_mc, _superGoodEndingVar, MathOperation.Add, 1);
            MCSay(builder, "Давай, я помогу тебе. Что думаешь?");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Delay(2f);
            builder.ChangeAppearance(_sonya, _smilingAppKey);
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
            builder.ChangeAppearance(_sonya, _upsetAppKey);
            builder.Move(_sonya, 0.3f);
            builder.Say(_sonya, "Я выросла в достаточно бедной семье.");
            builder.ChangeBG(_breadForPoorsBG);
            builder.Say(_sonya, "Помню времена, когда у нас дома из еды был только" +
                " черствый хлеб.");
            builder.Say(_sonya, "Каждый раз, глотая его, я обещала сама себе, что в" +
            " будущем смогу заработать столько денег, что никогда больше не буду" +
            " испытывать голод.");
            builder.ChangeBG(_street2BG);
            builder.Say(_sonya, "Теперь у меня достаточно средств на жизнь, но страх всё еще" +
                " преследует меня.");
            builder.Say(_sonya, "Боюсь, что однажды тот день из детства повторится...");
            builder.Say(_sonya, "...что в холодильнике ничего не найдется...");
            builder.Say(_sonya, "Этот страх мотивирует меня на поиск сокровища!");
            builder.Say(_sonya, "Сокровища, которое принесёт мне много денег!");
            builder.Say(_sonya, "Тогда я буду уверена, что никогда не останусь без еды...");

            MCThink(builder, "Соня выглядит очень расстроенной...");

            builder.BeginSelector("Соня выглядит очень расстроенной");
            builder.BeginSelectorVariant("Обнять её");
            builder.EndSelectorVariant(HugSonyaLabel);

            builder.BeginSelectorVariant("Обнять её");
            builder.EndSelectorVariant(NotHugSonyaLabel);
            builder.EndLabel();
            #endregion

            #region HugSonya
            builder.BeginLabel(HugSonyaLabel);
            builder.ChangeVariable(_mc, _superGoodEndingVar, MathOperation.Add, 1);
            builder.Hide(_sonya);
            builder.ChangeBG(_sonyaAndMcHuggingBG);
            MCSay(builder, "Я понимаю, как это неприятно, когда у тебя не хватает даже" +
                "самого нужного.");
            MCSay(builder, "Соня, мы с тобой вместе найдём это сокровище.");
            MCSay(builder, "И оно уберёт все твои страхи.");
            MCSay(builder, "Не волнуйся, я всегда буду рядом поддерживать тебя.");
            MCSay(builder, "И не важно, что нас ждёт на этом пути");
            builder.ChangeBG(_sonyaAndMcHugging2BG);
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
            builder.Show(_sonya, 0.1f, null);
            builder.Say(_sonya, "Смотри! Мы можем переждать дождь в этом доме.");
            MCSay(builder, "Думаешь, там никто не живет?");
            builder.Say(_sonya, "Нет, конечно. У него же окна забиты.");
            MCSay(builder, "Ты права. К тому же, я ни разу не видел света за этими забитыми окнами." +
                " Там извечно царит мрак...");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
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
            builder.ChangeAppearance(_sonya, _idkLolAppKey);
            builder.Say(_sonya, "А приведений?");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, "Ладно, бежим, скорее, в дом, а то до нитки промокнем!");
            builder.Jump(AfterMonstersLabel);
            builder.EndLabel();
            #endregion

            #region ImAfraidOfMonsters
            builder.BeginLabel(ImAfraidOfMonstersLabel);
            MCThink(builder, "Ну боюсь...");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Delay(1.5f);
            builder.ChangeAppearance(_sonya, _thinkingAppKey);
            builder.Delay(1.5f);
            builder.ChangeAppearance(_sonya, _smilingAppKey);
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
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
            builder.Say(_sonya, "Что случилось?!");
            MCSay(builder, "Ничего, просто показалось, идём в дом.");
            builder.ChangeAppearance(_sonya, _idkLolAppKey);
            builder.Delay(1.2f);
            builder.Jump(AfterMonstersLabel);
            builder.EndLabel();
            #endregion

            #region AfterMonsters
            builder.Hide(_sonya);
            builder.BeginLabel(AfterMonstersLabel);
            builder.ChangeBG(_insideCursedOldHouseBG);
            builder.EndSoundLoop(_rainSoundLoop);
            MCThink(builder, "Изнутри этот дом выглядел ничем не лучше, чем снаружи.");
            MCThink(builder, "Впрочем, крыша есть - уже хорошо.");
            builder.BeginSoundLoop(_campfireSoundLoop);
            builder.Delay(1.4f);
            builder.ChangeBG(_campfireInsideCursedOldHouseBG);
            builder.Delay(0.6f);
            MCThink(builder, "Мы разожгли костер, чтобы согреться.");
            builder.Show(_sonya, 0.3f, _neutralFaceAppKey);
            builder.Say(_sonya, "Ты куришь?");
            MCSay(builder, "Нет. Курить - здоровью вредить!");
            builder.Say(_sonya, "Понятно...");
            builder.Delay(1.4f);
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
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


            MCThink(builder, "");
            #region AfterCampfire
            builder.BeginLabel(AfterCampfireLabel);

            builder.EndLabel();
            #endregion

            return builder.Build();
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
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, "Ну, понятно.");
            builder.Say(_sonya, "Гигант мысли, получается?");
            MCSay(builder, "Получается.");
            MCThink(builder, "Фуф, пронесло...");
            builder.Jump(nextLabel);
            builder.EndLabel();


            builder.BeginLabel(MyDreamsLabel);
            MCSay(builder, "...сны свои смотрю. У меня нет ни кровати, ни телевизора, а тогда - даже зажигалки не было.");
            MCSay(builder, "Ну и купил, вот.");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "Ну, понятно.");
            MCThink(builder, "Странно получилось, конечно, но...");
            MCThink(builder, "...");
            MCThink(builder, "...вроде, прокатило...");
            builder.Jump(nextLabel);
            builder.EndLabel();


            builder.BeginLabel(WhyLighterAfterElevatorContinueLabel);
            MCSay(builder, "Возвращаясь к теме зажигалки...");
            builder.ChangeAppearance(_sonya, _neutralFaceAppKey);
            MCSay(builder, "В общем, я еще с детства хотел себе автомобиль.");
            MCSay(builder, "Но с этим постоянно были какие-то проблемы.");
            MCSay(builder, "То права нельзя получить в 13 лет...");
            MCSay(builder, "То нет денег на автошколу...");
            builder.ChangeAppearance(_sonya, _upsetAppKey);
            MCSay(builder, "То нет денег на сам автомобиль...");
            builder.Say(_sonya, "...");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, "Если мы... нет.");
            builder.Say(_sonya, "КОГДА мы найдём сокровище...");
            builder.Say(_sonya, "Мы оба сможем исполнить свои мечты!");
            builder.Say(_sonya, "Я смогу купить себе сухпайков на 100 лет вперёд, а ты...");
            builder.ChangeAppearance(_sonya, _superHappyAppKey);
            builder.Say(_sonya, "Ты купишь себе автомобиль, который всегда хотел!");
            MCSay(builder, "...");
            MCSay(builder, "А?");
            MCSay(builder, "Нет.");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Delay(1f);
            MCSay(builder, "Нет, сейчас-то у меня есть деньги на автомобиль - проблема в другом.");
            MCSay(builder, "Видишь ли, как я и говорил, я 5 дней в неделю - работаю на работе, в офисе," +
                " буквально через дорогу от моего дома.");
            builder.ChangeAppearance(_sonya, _upsetAppKey);
            MCSay(builder, "А оставшиеся 2 дня выходных я, собственно, не выхожу никуда - нет ни сил, ни желания.");
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
            builder.Say(_sonya, "А");
            builder.StartNsfwMiniGame(WhyLighterAfterElevatorAfterNsfwFinalLabel);
            builder.EndLabel();


            builder.BeginLabel(WhyLighterAfterElevatorAfterNsfwFinalLabel);
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "Так и зачем же тебе зажигалка?");
            MCSay(builder, "Хоть кататься на автомобиле мне некуда, на лифте я катаюсь каждый день.");
            builder.ChangeAppearance(_sonya, _neutralFaceAppKey);
            builder.Say(_sonya, "...");
            MCSay(builder, "С первого этажа до 25, а потом обратно, а потом на другое обратно...");
            MCSay(builder, "И так, пока все кнопки не расплавлю.");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Say(_sonya, "...");
            MCSay(builder, "Зажигалкой-то.");
            builder.ChangeAppearance(_sonya, _thinkingAppKey);
            builder.Say(_sonya, ".");
            builder.Say(_sonya, "..");
            builder.Say(_sonya, "...");
            builder.ChangeAppearance(_sonya, _neutralFaceAppKey);
            builder.Say(_sonya, "Ладно.");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
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
            builder.ChangeAppearance(_sonya, _neutralFaceAppKey);
            builder.Delay(1.4f);
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, "Ого, ты тоже её смотришь?");
            MCThink(builder, "Вообще-то, нет...");
            MCThink(builder, "Но, в любом случае, надо попытаться поддержать разговор, иначе" +
                " придётся использовать секретное оружие...");
            MCThink(builder, "Да, есть немного...");
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
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
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, "А какая машина тебе больше всего понравилась?");
            builder.Selector("Какая машина больше всего понравилась?",
                ("Стиральная", LeaveAfterYes),
                ("Мерседес", LeaveAfterYes),
                ("Электронная вычислительная", FailAfterYes),
                ("[Использовать секретное оружие]", SecretWeaponAfterYes));
            builder.EndLabel();

            builder.BeginLabel(LeaveAfterYes);
            builder.ChangeAppearance(_sonya, _idkLolAppKey);
            builder.Delay(0.4f);
            builder.Say(_sonya, "Да? А мне - швейная.");
            MCSay(builder, "Ну, как говорится - \"на вкус и цвет...\"");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            builder.Say(_sonya, "...все фломастеры разные.");
            MCThink(builder, "О, как.");
            builder.Jump(nextLabel);
            builder.EndLabel();

            builder.BeginLabel(FailAfterYes);
            builder.ChangeAppearance(_sonya, _thinkingAppKey);
            builder.Say(_sonya, "...");
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
            builder.Say(_sonya, "Не было там электронной вычислительной машины никакой!");
            MCThink(builder, "Блин, не угадал...");
            builder.Say(_sonya, "Нормально ты мне наплёл с 3 короба...");
            builder.ChangeAppearance(_sonya, _upsetAppKey);
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
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            MCSay(builder, "Каждая машина - просто ВЫСШИЙ КЛАСС!");
            MCSay(builder, "И испытания - огонь, вообще!");
            MCSay(builder, "Особенно мне то, где тот мужик руками водил, понравилось.");
            MCSay(builder, "Но выше всех похвал - тот момент...");
            MCSay(builder, "Понимаешь, о каком я?");
            builder.ChangeAppearance(_sonya, _superHappyAppKey);
            builder.Say(_sonya, "Понимаю, но ты всё равно скажи!");
            MCSay(builder, "Я о том моменте, когда...");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
            MCSay(builder, "...тому парню в шапке завязали глаза, а потом отправили его в другую комнату...");
            MCSay(builder, "...и там его попросили отгадать код от сейфа...");
            MCSay(builder, "...и вот он, перед сейфом встал...");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
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
            builder.ChangeAppearance(_sonya, _noodlesOnEarsAppKey);
            MCSay(builder, "Лапша, которую я тебе на уши вешаю.");
            builder.Say(null, "Секретное оружие", "Миссия выполнена.");
            MCThink(builder, "Я потратил своё единственное секретное оружие.");
            MCThink(builder, "Теперь придется подходить к выборам с бо́льшей ответственностью.");
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "А?");
            builder.Say(_sonya, "Ой, извини, что-то я из темы выпала...");
            builder.Say(_sonya, "На чем мы остановились?");
            MCSay(builder, "Мы хотели погреться у костра.");
            builder.ChangeAppearance(_sonya, _smilingAppKey);
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
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Delay(0.75f);
            MCSay(builder, "Из чего состоит романтический коктейль \"69\"?");
            builder.Say(_sonya, "...");
            builder.Say(_sonya, "э-э-э... из чего?..");
            MCSay(builder, "Из Балтики 9...");
            MCSay(builder, "... и Балтики 6!");
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
            builder.Delay(3f);
            builder.Say(_sonya, "Но по правилам джема нельзя использовать 18+ контент!");
            MCSay(builder, "...");
            MCSay(builder, "А обе Балтики - безалкогольные!");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
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
            builder.ChangeAppearance(_sonya, _idkLolAppKey);
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
            builder.ChangeAppearance(_sonya, _vahuiAppKey);
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
            builder.ChangeAppearance(_sonya, _thinkingAppKey);
            builder.Delay(1f);
            MCSay(builder, "...и доверяешь!");
            builder.ChangeAppearance(_sonya, _huhStarringAppKey);
            builder.Delay(2f);
            builder.ChangeAppearance(_sonya, _smilingAppKey);
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
    }
}
