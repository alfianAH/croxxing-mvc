using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.ScoreCalculator
{
    public class ScoreCalculatorController: DataController<ScoreCalculatorController, ScoreCalculatorModel, IScoreCalculatorModel>
    {
        public void OnAddScore(AddScoreMessage message)
        {
            _model.AddScore(message.AdditionalScore);
            Publish(new UpdateScoreMessage(_model.Score));
        }
    }
}