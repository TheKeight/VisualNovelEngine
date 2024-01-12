﻿using UnityEngine;
using NovelEngine.CommandHandlers.UX;
using NovelEngine.Commands;

namespace NovelEngine.CommandHandlers
{
    public sealed class ChangeBackGroundMusicCommandHandler : CommandHandlerComponent<ChangeBackGroundMusicCommand>
    {
        [SerializeField] private BgmManager _bgmManager;
        [SerializeField] private bool _shuffle = true;


        public override void Handle(ChangeBackGroundMusicCommand command)
        {
            _bgmManager.ChangePlaylist(command.PlayList, _shuffle);
            _bgmManager.Play();
        }
    }
}