using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.GameOver;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.Gameplay.Player.PlayerManager;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using Croxxing.Module.Scene.Gameplay.VehiclePool;

namespace Croxxing.Module.Scene.Gameplay.Connector
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerInputController _playerMovementController;
        private RoadPoolController _roadPoolController;
        private PlayerManagerController _playerManagerController;
        private VehiclePoolController _vehiclePoolController;
        private GameOverController _gameOverController;

        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(OnStartPlay);
            Subscribe<PlayerOnLastRoadMessage>(PlayerOnLastRoad);
            Subscribe<GameOverMessage>(OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(OnStartPlay);
            Unsubscribe<PlayerOnLastRoadMessage>(PlayerOnLastRoad);
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
            _roadPoolController.OnGameOver();
            _playerMovementController.OnGameOver();
        }
    }
}