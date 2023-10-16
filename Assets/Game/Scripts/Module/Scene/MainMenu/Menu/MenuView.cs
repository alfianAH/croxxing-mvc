using Agate.MVC.Base;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.MainMenu.Menu
{
    public class MenuView: BaseView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;

        public void SetCallbacks(UnityAction onClickPlayButton, UnityAction onClickSettingsButton, UnityAction onClickCreditsButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);

            _settingsButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.AddListener(onClickSettingsButton);

            _creditsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.AddListener(onClickCreditsButton);
        }
    }
}