using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.DistanceCalculator
{
    public class DistanceCalculatorConnector : BaseConnector
    {
        private DistanceCalculatorController _distanceCalculatorController;

        protected override void Connect()
        {
            Subscribe<AddDistanceMessage>(_distanceCalculatorController.AddDistance);
        }

        protected override void Disconnect()
        {
            Subscribe<AddDistanceMessage>(_distanceCalculatorController.AddDistance);
        }
    }
}