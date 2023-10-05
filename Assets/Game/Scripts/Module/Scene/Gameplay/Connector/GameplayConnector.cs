using Agate.MVC.Base;
using Croxxing.Module.Message;
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

        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(OnStartPlay);
            Subscribe<PlayerOnLastRoadMessage>(PlayerOnLastRoad);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(OnStartPlay);
            Unsubscribe<PlayerOnLastRoadMessage>(PlayerOnLastRoad);
        }

        private void OnStartPlay(StartPlayMessage message)
        {
            _playerMovementController.OnStartPlay();
            _roadPoolController.OnStartPlay();
        }

        private void PlayerOnLastRoad(PlayerOnLastRoadMessage message)
        {
            _playerManagerController.UpdatePositionOnLastRoad(message);
            _vehiclePoolController.PlayerOnLastRoad();
            _roadPoolController.PlayerOnLastRoad();
        }
    }
}