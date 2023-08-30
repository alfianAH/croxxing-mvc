using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.MainMenu.GameSettings
{
    public class GameSettingsView : BaseView
    {
        [Header("Menu Buttons")]
        [SerializeField] private Button _audioMenuButton;
        [SerializeField] private Button _controlsMenuButton;

        [Header("Menu Button Texts")]
        [SerializeField] private Text _audioMenuButtonText;
        [SerializeField] private Text _controlsMenuButtonText;
        [SerializeField] private List<Text> _menuButtonTexts;

        [Header("Menu Panel")]
        [SerializeField] private GameObject _audioMenuPanel;
        [SerializeField] private GameObject _controlsMenuPanel;
        [SerializeField] private List<GameObject> _menuPanels;

        public void SetCallbacks(UnityAction onClickAudioMenuButton,  UnityAction onClickControlsMenuButton)
        {
            _audioMenuButton.onClick.RemoveAllListeners();
            _audioMenuButton.onClick.AddListener(onClickAudioMenuButton);

            _controlsMenuButton.onClick.RemoveAllListeners();
            _controlsMenuButton.onClick.AddListener(onClickControlsMenuButton);
        }

        public void ActivateAudioMenu()
        {
            ActivateMenu(_audioMenuPanel, _audioMenuButtonText);
        }

        public void ActivateControlsMenu()
        {
            ActivateMenu(_controlsMenuPanel, _controlsMenuButtonText);
        }

        private void Start()
        {
            ActivateAudioMenu();
        }

        private void ActivateMenu(GameObject targetMenuPanel, Text targetMenuButtonText)
        {
            targetMenuPanel.SetActive(true);
            targetMenuButtonText.color = Color.white;

            // Deactivate unused menu panel
            foreach(GameObject menuPanel in _menuPanels)
            {
                if (menuPanel == targetMenuPanel || menuPanel == null) continue;
                menuPanel.SetActive(false);
            }
            // Deactivate unused menu button text
            foreach (Text menuButtonText in _menuButtonTexts)
            {
                if (menuButtonText == targetMenuButtonText || menuButtonText == null) continue;
                menuButtonText.color = Color.gray;
            }
        }
    }
}