namespace Croxxing.Module.Message
{
    public struct UpdateControlsMessage
    {
        public string ActionJson { get; private set; }
        public string ActionName { get; private set; }

        public UpdateControlsMessage(string actionJson, string actionName)
        {
            ActionJson = actionJson;
            ActionName = actionName;
        }
    }
}