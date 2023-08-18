using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.TapAnywhereInput
{
    public class TapAnywhereController : BaseController<TapAnywhereController>
    {
        private StartCountdownModel _startCountdownModel;
        
        public void OnTapAnywhere(StartCountdownView view)
        {
            _startCountdownModel = new StartCountdownModel(5);
            view.SetModel(_startCountdownModel);
            view.Init(TickTimer);
            StartTimer();
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
