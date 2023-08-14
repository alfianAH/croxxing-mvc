using Agate.MVC.Base;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Croxxing.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _creditsButton;

        public void SetCallbacks(UnityAction onClickPlayButton, UnityAction onClickCreditsButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
            
            _creditsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.AddListener(onClickCreditsButton);
        }
    }
}
