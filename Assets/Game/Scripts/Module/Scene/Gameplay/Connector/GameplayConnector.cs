using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.Audios.SoundEffect;
using Croxxing.Module.Scene.Gameplay.GameOver;
using Croxxing.Module.Scene.Gameplay.GamePause;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.Gameplay.Player.PlayerManager;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using Croxxing.Module.Scene.Gameplay.VehiclePool;
using Croxxing.Utility;

namespace Croxxing.Module.Scene.Gameplay.Connector
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerInputController _playerMovementController;
        private RoadPoolController _roadPoolController;
        private PlayerManagerController _playerManagerController;
        private VehiclePoolController _vehiclePoolController;
        private GameOverController _gameOverController;
        private GamePauseController _gamePauseController;
        private SoundEffectController _soundEffectController;

        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(OnStartPlay);
            Subscribe<PlayerOnLastRoadMessage>(PlayerOnLastRoad);
            Subscribe<GamePausedMessage>(OnGamePause);
            Subscribe<GameResumeMessage>(OnGameResume);
            Subscribe<GameOverMessage>(OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(OnStartPlay);
            Unsubscribe<PlayerOnLastRoadMessage>(PlayerOnLastRoad);
            Unsubscribe<GamePausedMessage>(OnGamePause);
            Unsubscribe<GameResumeMessage>(OnGameResume);
            Unsubscribe<GameOverMessage>(OnGameOver);
        }

        private void OnStartPlay(StartPlayMessage message)
        {
            _playerMovementController.OnStartPlay();
        }

        private void PlayerOnLastRoad(PlayerOnLastRoadMessage message)
        {
            _playerManagerController.UpdatePositionOnLastRoad(message);
            _vehiclePoolController.PlayerOnLastRoad();
            _roadPoolController.PlayerOnLastRoad();
        }

        private void OnGameOver(GameOverMessage message)
        {
            _gameOverController.OnGameOver();
            _roadPoolController.SetIsPlaying(false);
            _playerMovementController.OnGameOver();
            _soundEffectController.Play(AudioNames.SFX_CAR_CRASH);
        }

        private void OnGamePause(GamePausedMessage message)
        {
            _gamePauseController.OnGamePauseFromInput();
            _roadPoolController.SetIsPlaying(false);
        }

        private void OnGameResume(GameResumeMessage message)
        {
            _gamePauseController.OnGameResumeFromInput();
            _roadPoolController.SetIsPlaying(true);
        }
    }
}