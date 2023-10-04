using Agate.MVC.Base;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.Timer
{
    public class TimerView : ObjectView<ITimerModel>
    {
        [SerializeField] private Text _countdownText;
        [SerializeField] private Slider _countdownSlider;

        private Action _onUpdate;
        private Action _onStopTimer;

        public void Init(Action onUpdate, Action onInit = null, Action onStopTimer = null)
        {
            _onUpdate = onUpdate;
            _onStopTimer = onStopTimer;
            onInit?.Invoke();
        }

        private void Update()
        {
            _onUpdate?.Invoke();
        }

        public void StopCountdownIfCompleted()
        {
            StartCoroutine(StopTimer());
        }

        private IEnumerator StopTimer()
        {
            yield return new WaitUntil(() => _model.IsCompleted);
            _onUpdate = null;
            _onStopTimer?.Invoke();
        }

        protected override void InitRenderModel(ITimerModel model) { }

        protected override void UpdateRenderModel(ITimerModel model)
        {
            if(_countdownText != null)
                _countdownText.text = (model.Remaining / 1000.0f).ToString("0");
            
            if(_countdownSlider != null)
                _countdownSlider.value = model.Progress;
        }
    }
}