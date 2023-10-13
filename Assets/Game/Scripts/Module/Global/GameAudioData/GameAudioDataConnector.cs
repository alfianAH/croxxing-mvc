using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Global.GameAudioData
{
    public class GameAudioDataConnector : BaseConnector
    {
        private GameAudioDataController _gameAudioDataController;

        protected override void Connect()
        {
            Subscribe<UpdateVolumeMessage>(_gameAudioDataController.OnSliderValueChanged);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateVolumeMessage>(_gameAudioDataController.OnSliderValueChanged);
        }
    }
}