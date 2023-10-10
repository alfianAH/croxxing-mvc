using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.GameOver
{
    public class GameOverView : ObjectView<IGameOverModel>
    {
        [SerializeField] private GameObject _gameOverPanel;

        [Header("Buttons")]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

        [Header("Texts")]
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _highScoreText;
        [SerializeField] private Text _distanceText;
        [SerializeField] private Text _longestDistanceText;

        public void SetCallbacks(UnityAction onRestartButtonClick, UnityAction onHomeButtonClick)
        {
            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(onRestartButtonClick);

            _homeButton.onClick.RemoveAllListeners();
            _homeButton.onClick.AddListener(onHomeButtonClick);
        }

        public void ShowGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }

        private void UpdateTexts(IGameOverModel model)
        {
            _scoreText.text = $"Score: {model.Score}";
            _highScoreText.text = $"High Score: {model.HighScore}";
            _distanceText.text = $"Distance: {model.Distance}";
            _longestDistanceText.text = $"Longest Distance: {model.LongestDistance}";
        }

        protected override void InitRenderModel(IGameOverModel model)
        {
            UpdateTexts(model);
        }

        protected override void UpdateRenderModel(IGameOverModel model)
        {
            UpdateTexts(model);
        }
    }
}