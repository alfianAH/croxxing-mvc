using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.ScoreCalculator
{
    public interface IScoreCalculatorModel: IBaseModel
    {
        public int Score { get; }
    }
}