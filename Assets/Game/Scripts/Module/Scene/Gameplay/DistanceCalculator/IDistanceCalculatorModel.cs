using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.DistanceCalculator
{
    public interface IDistanceCalculatorModel: IBaseModel
    {
        public int Distance { get; }
    }
}