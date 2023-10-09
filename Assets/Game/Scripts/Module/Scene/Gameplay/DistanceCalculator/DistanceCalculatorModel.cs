using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.DistanceCalculator
{
    public class DistanceCalculatorModel: BaseModel, IDistanceCalculatorModel
    {
        public int Distance { get; private set; } = 0;

        public void AddDistance()
        {
            Distance++;
            SetDataAsDirty();
        }
    }
}