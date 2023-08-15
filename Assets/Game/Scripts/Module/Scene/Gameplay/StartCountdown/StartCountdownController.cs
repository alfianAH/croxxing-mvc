using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownController : ObjectController<StartCountdownController, StartCountdownModel, IStartCountdownModel, StartCountdownView>
    {
        public override void SetView(StartCountdownView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickAnywhere);
        }

        private void OnClickAnywhere()
        {
            _model.SetTimer(3);
            _model.TimerCountdown();
        }
    }
}