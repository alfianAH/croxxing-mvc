using Agate.MVC.Base;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownView : ObjectView<IStartCountdownModel>
    {
        [SerializeField] private Text _countdownInstruction;
        [SerializeField] private Text _countdownText;
        [SerializeField] private Slider _countdownSlider;

        private Action _onUpdate;

        public void Init(Action onUpdate)
        {
            _onUpdate = onUpdate;
        }

        private void Update()
        {
            _onUpdate?.Invoke();
        }

        protected override void InitRenderModel(IStartCountdownModel model)
        {
            
        }

        protected override void UpdateRenderModel(IStartCountdownModel model)
        {
            _countdownText.text = ((float)model.Remaining / 1000.0f).ToString("F2");
            _countdownSlider.value = model.Progress;
        }
    }
}