using System;
using System.Diagnostics;
using UnityEngine;

namespace NovelEngine.UX.MiniGames
{
    public sealed class UrlOpenerOnAwake : MonoBehaviour
    {
        [SerializeField] private string _url = @"https://vk.com/topic-223504963_49582693";


        private void Awake()
        {
            try
            {
                var process = Process.Start(_url);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.Message);
            }
        }
    }
}
