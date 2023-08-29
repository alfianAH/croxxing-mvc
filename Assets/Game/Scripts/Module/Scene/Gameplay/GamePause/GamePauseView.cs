using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.GamePause
{
    public class GamePauseView: BaseView
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private GameObject _pausePanel;

        public void SetCallbacks(UnityAction onClickPauseButton, UnityAction onClickResumeButton)
        {
            _pauseButton.onClick.RemoveAllListeners();
            _pauseButton.onClick.AddListener(onClickPauseButton);

            _resumeButton.onClick.RemoveAllListeners();
            _resumeButton.onClick.AddListener(onClickResumeButton);
        }

        public void ActivatePausePanel()
        {
            _pausePanel.SetActive(true);
        }

        public void DeactivatePausePanel()
        {
            _pausePanel.SetActive(false);
        }
    }
}