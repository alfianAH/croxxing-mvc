using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownController : ObjectController<StartCountdownController, StartCountdownModel, StartCountdownView>
    {
        public override IEnumerator Initialize()
        {
            _model.SetTimer(3);
            yield return base.Initialize();
        }

        public void OnTapAnywhere(TapAnywhereMessage message)
        {
            _view.Timer.SetModel(_model.Timer);
            _view.Timer.Init(TickTimer, _view.Init, _view.OnStopTimer);
            StartTimer();
            _view.Timer.StopCountdownIfCompleted();
        }

        private void StartTimer()
        {
            _model.Timer.StartCountdown(GameUtils.GetCurrentTime());
        }

        private void TickTimer()
        {
            long currentTime = GameUtils.GetCurrentTime();
            _model.Timer.UpdateCountdown(currentTime);
            if (_model.Timer.IsCompleted)
            {
                Publish(new StartPlayMessage());
            }
        }
    }
}
