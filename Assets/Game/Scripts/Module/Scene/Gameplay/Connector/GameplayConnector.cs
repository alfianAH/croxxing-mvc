using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.Gameplay.RoadPool;

namespace Croxxing.Module.Scene.Gameplay.Connector
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerInputController _playerMovementController;
        private RoadPoolController _roadPoolController;

        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(OnStartPlay);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(OnStartPlay);
        }

        private void OnStartPlay(StartPlayMessage message)
        {
            _playerMovementController.OnStartPlay();
            _roadPoolController.OnStartPlay();
        }
    }
}