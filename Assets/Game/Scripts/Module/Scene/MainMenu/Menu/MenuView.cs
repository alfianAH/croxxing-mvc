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
        [SerializeField] private Button _closeSettingsButton;

        [SerializeField] private GameObject _settingsPanel;

        public void SetCallbacks(
            UnityAction onClickPlayButton, 
            UnityAction onClickSettingsButton, 
            UnityAction onClickCreditsButton,
            UnityAction onCloseSettingsButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);

            _settingsButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.AddListener(onClickSettingsButton);

            _creditsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.AddListener(onClickCreditsButton);

            _closeSettingsButton.onClick.RemoveAllListeners();
            _closeSettingsButton.onClick.AddListener(onCloseSettingsButton);
        }

        public void SetActiveSettingPanel(bool isActive)
        {
            _settingsPanel.SetActive(isActive);
        }
    }
}