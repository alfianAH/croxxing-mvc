using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownConnector: BaseConnector
    {
        private StartCountdownController _startCountdownController;

        protected override void Connect()
        {
            Subscribe<TapAnywhereMessage>(_startCountdownController.OnTapAnywhere);
        }

        protected override void Disconnect()
        {
            Unsubscribe<TapAnywhereMessage>(_startCountdownController.OnTapAnywhere);
        }
    }
}