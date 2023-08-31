using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.GamePause
{
    public class GamePauseConnector : BaseConnector
    {
        private GamePauseController _gamePauseController;

        protected override void Connect()
        {
            Subscribe<GameResumeMessage>(_gamePauseController.OnGameResumeFromInput);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameResumeMessage>(_gamePauseController.OnGameResumeFromInput);
        }
    }
}