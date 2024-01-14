using System.Diagnostics;
using System.IO;
using System.Linq;
using NovelEngine.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace NovelEngine.UX.MiniGames
{
    public sealed class NsfwMiniGame : MonoBehaviour
    {
        private const string FileName = "game.properties";
        private const string FileLine = "allownsfw = true";

        [SerializeField] private UnityMessageBoxOkX _nswfIsNotAllowedMessageBoxPrefab;
        [SerializeField] private Transform _mboxParent;
        [SerializeField] private Button _bVariantBtn;
        [SerializeField] private Button _hereIsYourDVariantBtn;
        [SerializeField] private string _openInBrowserLink = @"https://www.youtube.com/watch?v=dQw4w9WgXcQ";
        [SerializeField]
        private string[] _openInBrowserRandomLinks = new string[]
        {
            @"https://www.youtube.com/watch?v=LLFhKaqnWwk",
            @"https://www.youtube.com/watch?v=rTga41r3a4s",
            @"https://www.youtube.com/watch?v=MXMf_ni0Msk",
            @"https://www.youtube.com/watch?v=WUHf2NrKn74",
            @"https://www.youtube.com/watch?v=iSge47buiaw",
        };

        [SerializeField] private string _mboxHeadMsg = "NSFW контент заблокирован";
        [SerializeField, TextArea(3, 6)]
        private string _mboxBodyMsg = "Текущая конфигурация приложения не разрешает" +
            " небезопасный контент. Если вы хотите видеть его в игре - создайте конфигурационный файл" +
            $" с названием \"{FileName}\" и поместите его в папку с игрой (там, где находится файл" +
            " для запуска приложения). Убедитесь, что в файле конфигурации имеется строка, разрешающая" +
            $" небезопасный контент: \"{FileLine}\" (без кавычек). Для применения изменений -" +
            " перезапустите приложение.";

        private System.Action _bEndingCallback;
        private bool _nsfwWasAllowedAtStart;


        private void Awake()
        {
            _bVariantBtn.onClick.AddListener(HandleB);
            _hereIsYourDVariantBtn.onClick.AddListener(HandleD);

            CheckConfig(out bool fileFound, out bool nsfwAllowed);
            _nsfwWasAllowedAtStart = nsfwAllowed;
        }


        public void Init(System.Action bEndingCallback)
        {
            _bEndingCallback = bEndingCallback;
        }

        private void HandleB()
        {
            Destroy(gameObject);
            _bEndingCallback?.Invoke();
        }

        private void HandleD()
        {
            CheckConfig(out bool fileFound, out bool nsfwAllowed);
            UnityEngine.Debug.Log(Directory.GetCurrentDirectory());
            UnityEngine.Debug.Log($"{fileFound}, {nsfwAllowed}");

            if (nsfwAllowed && _nsfwWasAllowedAtStart)
            {
                OpenLink(_openInBrowserLink);
                return;
            }

            if (!nsfwAllowed)
            {
                var mbox = Instantiate(_nswfIsNotAllowedMessageBoxPrefab, _mboxParent);
                mbox.Init(_mboxHeadMsg, _mboxBodyMsg, null, null);
                return;
            }

            if (!_nsfwWasAllowedAtStart)
            {
                RequestTroll();
                return;
            }

           
        }

        private void CheckConfig(out bool fileFound, out bool nsfwAllowed)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), FileName);
            fileFound = File.Exists(filePath);

            if (!fileFound)
            {
                filePath += ".txt";
                fileFound = File.Exists(filePath);
            }

            if (!fileFound)
            {
                nsfwAllowed = false;
                return;
            }

            var lines = File.ReadAllLines(filePath);
            string unifiedLineContent = FileLine.ToLower().Replace(" ", string.Empty);
            nsfwAllowed = lines.Any(s => s.ToLower().Replace(" ", string.Empty) == unifiedLineContent);
        }

        private void RequestTroll()
        {
            var mbox = Instantiate(_nswfIsNotAllowedMessageBoxPrefab, _mboxParent);
            mbox.Init("Необходим перезапуск", "Файл конфигурации обнаружен, но" +
                " приложение не было перезапущено. Продолжение выполнения может" +
                " привести к неожиданным результатам. Нажмите ОК для продолжения," +
                " нажмите крестик для отмены.", ConfirmTroll, null);
        }

        private void ConfirmTroll()
        {
            OpenLink(_openInBrowserRandomLinks[UnityEngine.Random.Range(0, _openInBrowserRandomLinks.Length)]);
        }

        private void OpenLink(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (System.Exception ex)
            {
                UnityEngine.Debug.LogError(ex.Message);
            }
        }
    }
}
