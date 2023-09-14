namespace Croxxing.Module.Message
{
    public struct UpdateControlsMessage
    {
        public string ActionJson { get; private set; }

        public UpdateControlsMessage(string actionJson)
        {
            ActionJson = actionJson;
        }
    }
}