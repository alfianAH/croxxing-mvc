using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.ScoreCalculator
{
    public class ScoreCalculatorConnector : BaseConnector
    {
        private ScoreCalculatorController _scoreCalculatorController;

        protected override void Connect()
        {
            Subscribe<AddScoreMessage>(_scoreCalculatorController.OnAddScore);
        }

        protected override void Disconnect()
        {
            Unsubscribe<AddScoreMessage>(_scoreCalculatorController.OnAddScore);
        }
    }
}