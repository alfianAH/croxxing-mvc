using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownView : ObjectView<IStartCountdownModel>
    {
        [SerializeField] private Text _countdownText;
        [SerializeField] private Button _countdownButton;

        public void SetCallbacks(UnityAction onClickAnywhere)
        {
            _countdownButton.onClick.RemoveAllListeners();
            _countdownButton.onClick.AddListener(onClickAnywhere);
        }

        protected override void InitRenderModel(IStartCountdownModel model)
        {
            _countdownText.text = model.Timer.ToString();
        }

        protected override void UpdateRenderModel(IStartCountdownModel model)
        {
            _countdownText.text = model.Timer.ToString();
        }
    }
}