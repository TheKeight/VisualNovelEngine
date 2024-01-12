using System;
using System.Threading;
using System.Threading.Tasks;
using DevourDev.CommandSystem;
using DevourDev.CommandSystem.Interfaces;
using DevourDev.Unity.NovelEngine.Builders.BaseBuilder;
using DevourDev.Unity.NovelEngine.Commands;
using DevourDev.Unity.NovelEngine.Entities;
using DevourDev.Utility;

namespace DevourDev.Unity.NovelEngine.Tests.SimpleTest
{
    public static class SimpleTestHelpers
    {
        public async static void RunSimpleTester()
        {
            var simpleTester = new SimpleTester(UnityEngine.Debug.Log);
            using var cts = new CancellationTokenSource();
            cts.CancelAfter(30_000);

            await simpleTester.Test(GetBuilder(), cts.Token);
        }

        private static IBuilder<NovelScriptData> GetBuilder()
        {
            var builder = new NovelScriptBuilder();
            var pupa = Character.Create("Pupa", default, default);
            var lupa = Character.Create("Lupa", default, default);

            builder.BeginLabel("Жопа");
            builder.Say(pupa, "preved, ya PUPA!!!");
            builder.Say(lupa, "preved, PUPA, ya LUPA!!!");
            builder.BeginSelector("IDEM V BUHGALTERIJU???");
            builder.BeginSelectorVariant("DA");
            builder.EndSelectorVariant("V_BUH");
            builder.BeginSelectorVariant("NET((");
            builder.EndSelectorVariant("(((");
            builder.EndSelector();
            builder.EndLabel();

            builder.BeginLabel("(((");
            builder.Say(pupa, "pa4imu tak grustna...");
            builder.Say(lupa, "davay vernemsya nazad?");
            builder.BeginSelector("NAZAD???");
            builder.BeginSelectorVariant("DA");
            builder.EndSelectorVariant("Жопа");
            builder.BeginSelectorVariant("NET");
            builder.EndSelectorVariant("(((");
            builder.EndSelector();
            builder.EndLabel();

            builder.BeginLabel("V_BUH");
            builder.Say(pupa, "PEREPUTALI SUKI!!!");
            builder.Jump("(((");
            builder.EndLabel();
            return builder;
        }
    }
    public sealed class SimpleTester
    {
        private sealed class TestNovelPlayer
        {
            private abstract class TestHandler<TCmd> : ICommandHandler<TCmd>
                where TCmd : ICommand
            {
                private readonly System.Action<string> _logAction;


                protected TestHandler(Action<string> logAction)
                {
                    _logAction = logAction;
                }


                public System.Type HandlingCommandType => typeof(TCmd);
                public abstract void Handle(TCmd command);

                protected void Log(string msg)
                {
                    _logAction?.Invoke(msg);
                }
            }

            private sealed class SayHandler : TestHandler<SayCommand>
            {
                public SayHandler(Action<string> logAction) : base(logAction)
                {
                }

                public override void Handle(SayCommand command)
                {
                    Log($"{command.Speaker?.CharacterName}: {command.Speech}");
                }
            }

            private sealed class ShowCharacterHandler : TestHandler<ShowCharacterCommand>
            {
                public ShowCharacterHandler(Action<string> logAction) : base(logAction)
                {
                }

                public override void Handle(ShowCharacterCommand command)
                {
                    Log($"Showing {command.Character.CharacterName}");
                }
            }

            private sealed class ShowSelectorHandler : TestHandler<ShowSelectorCommand>
            {
                private readonly TestNovelPlayer _novelPlayer;


                public ShowSelectorHandler(Action<string> logAction, TestNovelPlayer novelPlayer) : base(logAction)
                {
                    _novelPlayer = novelPlayer;
                }


                public override void Handle(ShowSelectorCommand command)
                {
                    Log($"Showing Selector with {command.Variants.Count} commands");
                    var selectedVariant = command.Variants[0];
                    Log($"Selecting first variant: {selectedVariant.Title}");
                    _novelPlayer.Init(selectedVariant.Destination);
                    _novelPlayer.GoNext();
                }
            }

            private sealed class JumpHandler : TestHandler<JumpToStoryLineCommand>
            {
                private readonly TestNovelPlayer _novelPlayer;


                public JumpHandler(Action<string> logAction, TestNovelPlayer novelPlayer) : base(logAction)
                {
                    _novelPlayer = novelPlayer;
                }


                public override void Handle(JumpToStoryLineCommand command)
                {
                    Log($"Jumping to {command.Destination} ({command.Destination.Commands.Count} cmds)");
                    _novelPlayer.Init(command.Destination);
                    _novelPlayer.GoNext();
                }
            }


            private readonly ICommandsManager _commandsManager;
            private readonly System.Action<string> _logAction;
            private StoryLine _storyLine;
            private int _nextCommandIndex;


            public TestNovelPlayer(System.Action<string> logAction)
            {
                _logAction = logAction;
                _commandsManager = new CommandsManager();
                RegisterHandler(new SayHandler(Log));
                RegisterHandler(new ShowCharacterHandler(Log));
                RegisterHandler(new ShowSelectorHandler(Log, this));
                RegisterHandler(new JumpHandler(Log, this));
            }


            public bool CanGoNext
            {
                get
                {
                    return _storyLine != null && _storyLine.Commands != null
                        && _storyLine.Commands.Count > _nextCommandIndex;
                }
            }


            public void Init(StoryLine storyLine)
            {
                _storyLine = storyLine;
                _nextCommandIndex = 0;
            }

            public void GoNext()
            {
                var cmd = _storyLine.Commands[_nextCommandIndex++];
                _commandsManager.Handle(cmd);
            }

            private void Log(string msg)
            {
                _logAction?.Invoke($"TEST NOVEL PLAYER: \"{msg}\"");
            }

            private void RegisterHandler<TCmd>(TestHandler<TCmd> handler)
                    where TCmd : ICommand
            {
                _commandsManager.RegisterHandler(handler.HandlingCommandType, handler);
            }
        }

        private readonly System.Action<string> _logAction;
        private TestNovelPlayer _novelPlayer;


        public SimpleTester(Action<string> logAction)
        {
            _logAction = logAction;
        }


        public async Task Test(IBuilder<NovelScriptData> novelScriptBuilder, CancellationToken token = default)
        {
            Log($"Attempt to build {novelScriptBuilder}...");
            var data = novelScriptBuilder.Build();
            Log($"building completed");

            var startStoryLine = data.StoryLines[data.StartStoryLineIndex];
            Log("Initializing Test Novel Player...");
            _novelPlayer = new(_logAction);
            Log("Test Novel Player initialized");
            _novelPlayer.Init(startStoryLine);

            int counter = 1000;

            while (_novelPlayer.CanGoNext && --counter > 0)
            {
                if (token.IsCancellationRequested)
                {
                    Log("Cancellation requested. Cancelling...");
                    break;
                }

                _novelPlayer.GoNext();
                await Task.Delay(1000);
            }

            Log("Test finished.");
        }

        private void Log(string msg)
        {
            _logAction?.Invoke($"SIMPLE TESTER: \"{msg}\"");
        }
    }
}
