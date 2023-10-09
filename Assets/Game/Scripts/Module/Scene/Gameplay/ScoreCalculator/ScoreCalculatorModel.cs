using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.ScoreCalculator
{
    public class ScoreCalculatorModel: BaseModel, IScoreCalculatorModel
    {
        public int Score { get; private set; } = 0;

        public void AddScore(int score)
        {
            Score += score;
            SetDataAsDirty();
        }
    }
}