using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public class PlayerManagerConnector: BaseConnector
    {
        private PlayerManagerController _playerManagerController;

        protected override void Connect()
        {
            Subscribe<PlayerMovementMessage>(_playerManagerController.UpdateMovement);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PlayerMovementMessage>(_playerManagerController.UpdateMovement);
        }
    }
}