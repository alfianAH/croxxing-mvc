using Agate.MVC.Base;
using Croxxing.Module.Message;
using System;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownController : ObjectController<StartCountdownController, StartCountdownModel, IStartCountdownModel, StartCountdownView>
    {
        public void OnTapAnywhere(TapAnywhereMessage message)
        {
            _view.Init(TickTimer);
            StartTimer();
            _view.StopCountdownIfCompleted();
        }

        private void StartTimer()
        {
            _model.StartCountdown(GetCurrentTime());
        }

        private void TickTimer()
        {
            long currentTime = GetCurrentTime();
            _model.UpdateCountdown(currentTime);
            if (_model.IsCompleted)
            {
                Publish(new StartPlayMessage());
            }
        }

        private long GetCurrentTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}
