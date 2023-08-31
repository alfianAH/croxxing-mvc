using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;

namespace Croxxing.Module.Scene.Gameplay.Connector
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerInputController _playerMovementController;

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
        }
    }
}