using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.GamePause
{
    public class GamePauseConnector : BaseConnector
    {
        private GamePauseController _gamePauseController;
        protected override void Connect()
        {
            Subscribe<GamePausedMessage>(_gamePauseController.OnGamePauseFromInput);
            Subscribe<GameResumeMessage>(_gamePauseController.OnGameResumeFromInput);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GamePausedMessage>(_gamePauseController.OnGamePauseFromInput);
            Unsubscribe<GameResumeMessage>(_gamePauseController.OnGameResumeFromInput);
        }
    }
}