using Agate.MVC.Base;
using Croxxing.Boot;
using Croxxing.Module.Global.ProgressData;
using Croxxing.Module.Scene.Gameplay.DistanceCalculator;
using Croxxing.Module.Scene.Gameplay.ScoreCalculator;
using Croxxing.Utility;

namespace Croxxing.Module.Scene.Gameplay.GameOver
{
    public class GameOverController: ObjectController<GameOverController, GameOverModel, IGameOverModel, GameOverView>
    {
        private ProgressDataController _progressDataController;
        private ScoreCalculatorController _scoreCalculatorController;
        private DistanceCalculatorController _distanceCalculatorController;

        public void OnGameOver()
        {
            _view.SetCallbacks(OnRestartButtonClick, OnHomeButtonClick);

            // Set score
            _model.SetScore(_scoreCalculatorController.Model.Score);
            // Check high score
            CheckHighScore(_model.Score);
            // Set high score
            _model.SetHighScore(_progressDataController.Model.ProgressData.HighScore);

            // Set distance
            _model.SetDistance(_distanceCalculatorController.Model.Distance);
            // Check longest distance
            CheckLongestDistance(_model.Distance);
            // Set longest distance
            _model.SetLongestDistance(_progressDataController.Model.ProgressData.LongestDistance);

            _progressDataController.SaveProgress();
            _view.ShowGameOverPanel();
        }

        private void CheckHighScore(int currentScore)
        {
            if(currentScore > _progressDataController.Model.ProgressData.HighScore)
            {
                _progressDataController.SetHighScore(currentScore);
            }
        }

        private void CheckLongestDistance(int currentDistance)
        {
            if(currentDistance > _progressDataController.Model.ProgressData.LongestDistance)
            {
                _progressDataController.SetLongestDistance(currentDistance);
            }
        }

        private void OnRestartButtonClick()
        {
            SceneLoader.Instance.RestartScene();
        }

        private void OnHomeButtonClick()
        {
            SceneLoader.Instance.LoadScene(GameScenes.MAIN_MENU);
        }
    }
}