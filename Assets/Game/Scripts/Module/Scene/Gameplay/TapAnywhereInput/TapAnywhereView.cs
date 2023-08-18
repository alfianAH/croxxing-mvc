using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.TapAnywhereInput
{
    public class TapAnywhereView: BaseView
    {
        [SerializeField] private StartCountdownView _startCountdownView;

        private Action _onTapAnywhere;
        private bool _isFirstTime;

        public StartCountdownView CountdownView => _startCountdownView;

        public void OnTapAnywhere(Action onTapAnywhere)
        {
            _onTapAnywhere = onTapAnywhere;
        }

        public void StopCountdownIfCompleted()
        {
            StartCoroutine(_startCountdownView.StopTimer());
        }

        private void Awake()
        {
            _isFirstTime = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && _isFirstTime)
            {
                _isFirstTime = false;
                _onTapAnywhere?.Invoke();
            }
        }
    }
}