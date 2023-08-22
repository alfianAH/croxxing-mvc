using Croxxing.Module.Global.ControlsData;

namespace Croxxing.Module.Message
{
    public struct UpdateControlsMessage
    {
        public Controls ControlsData { get; private set; }

        public UpdateControlsMessage(Controls controlsData)
        {
            ControlsData = controlsData;
        }
    }
}