using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerInput
{
    public class PlayerInputConnector : BaseConnector
    {
        private PlayerInputController _playerMovementController;
        
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
