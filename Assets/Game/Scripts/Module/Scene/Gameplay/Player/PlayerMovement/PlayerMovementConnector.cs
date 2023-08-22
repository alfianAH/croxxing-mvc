using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerMovement
{
    public class PlayerMovementConnector : BaseConnector
    {
        private PlayerMovementController _playerMovementController;
        
        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(_playerMovementController.OnStartPlay);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(_playerMovementController.OnStartPlay);
        }
    }
}
