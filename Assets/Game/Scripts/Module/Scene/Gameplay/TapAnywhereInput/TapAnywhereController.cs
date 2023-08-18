using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.TapAnywhereInput
{
    public class TapAnywhereController : ObjectController<TapAnywhereController, TapAnywhereView>
    {
        private StartCountdownModel _startCountdownModel;
        private const int COUNTDOWN_SECONDS = 3;

        public override void SetView(TapAnywhereView view)
        {
            base.SetView(view);
            view.OnTapAnywhere(OnTapAnywhere);
        }

        public void OnTapAnywhere()
        {
            _startCountdownModel = new StartCountdownModel(COUNTDOWN_SECONDS);
            _view.CountdownView.SetModel(_startCountdownModel);
            _view.CountdownView.Init(TickTimer);
            StartTimer();
            _view.StopCountdownIfCompleted();
        }

        private void StartTimer()
        {
            _startCountdownModel.StartCountdown(GetCurrentTime());
        }

        private void TickTimer()
        {
            long currentTime = GetCurrentTime();
            _startCountdownModel.UpdateCountdown(currentTime);
            if (_startCountdownModel.IsCompleted)
            {
                Debug.Log("Start play");
            }
        }

        private long GetCurrentTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}
