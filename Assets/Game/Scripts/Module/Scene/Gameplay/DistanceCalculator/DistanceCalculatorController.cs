using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.DistanceCalculator
{
    public class DistanceCalculatorController: DataController<DistanceCalculatorController, DistanceCalculatorModel, IDistanceCalculatorModel>
    {
        public void AddDistance(AddDistanceMessage message)
        {
            _model.AddDistance();
            Publish(new UpdateDistanceMessage(_model.Distance));
        }
    }
}