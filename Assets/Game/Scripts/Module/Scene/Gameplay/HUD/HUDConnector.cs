using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.HUD
{
    public class HUDConnector : BaseConnector
    {
        private HUDController _hudController;

        protected override void Connect()
        {
            Subscribe<UpdateScoreMessage>(_hudController.UpdateScore);
            Subscribe<UpdateDistanceMessage>(_hudController.UpdateDistance);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateScoreMessage>(_hudController.UpdateScore);
            Unsubscribe<UpdateDistanceMessage>(_hudController.UpdateDistance);
        }
    }
}