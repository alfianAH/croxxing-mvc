using Agate.MVC.Base;
using System;
using System.Collections;
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
            _countdownInstruction.gameObject.SetActive(false);
            _countdownText.gameObject.SetActive(true);
            _countdownSlider.gameObject.SetActive(true);
        }

        public void StopCountdownIfCompleted()
        {
            StartCoroutine(StopTimer());
        }

        private IEnumerator StopTimer()
        {
            yield return new WaitUntil(() => _model.IsCompleted);
            _onUpdate = null;
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _countdownInstruction.gameObject.SetActive(true);
            _countdownText.gameObject.SetActive(false);
            _countdownSlider.gameObject.SetActive(false);
        }

        private void Update()
        {
            _onUpdate?.Invoke();
        }

        protected override void InitRenderModel(IStartCountdownModel model) { }

        protected override void UpdateRenderModel(IStartCountdownModel model)
        {
            _countdownText.text = (model.Remaining / 1000.0f).ToString("0");
            _countdownSlider.value = model.Progress;
        }
    }
}