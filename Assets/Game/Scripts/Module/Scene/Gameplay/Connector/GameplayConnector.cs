using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.GamePause;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.MainMenu.ControlSetting;

namespace Croxxing.Module.Scene.Gameplay.Connector
{
    public class GameplayConnector : BaseConnector
    {
        private PlayerInputController _playerMovementController;
        private GamePauseController _gamePauseController;
        private ControlSettingController _controlSettingController;

        protected override void Connect()
        {
            Subscribe<StartPlayMessage>(OnStartPlay);
            Subscribe<GamePausedMessage>(OnGamePause);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartPlayMessage>(OnStartPlay);
            Unsubscribe<GamePausedMessage>(OnGamePause);
        }

        private void OnStartPlay(StartPlayMessage message)
        {
            _playerMovementController.OnStartPlay();
        }

        private void OnGamePause(GamePausedMessage message)
        {
            _gamePauseController.OnGamePauseFromInput();
            _controlSettingController.UpdateBehaviour();
        }
    }
}