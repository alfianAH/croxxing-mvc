using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Global.ControlsData
{
    public class ControlsConnector : BaseConnector
    {
        private ControlsController _controlsController;

        protected override void Connect()
        {
            Subscribe<UpdateControlsMessage>(_controlsController.SetControlsData);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateControlsMessage>(_controlsController.SetControlsData);
        }
    }
}