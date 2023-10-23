namespace Croxxing.Module.Message
{
    public struct UpdateDistanceMessage
    {
        public int Distance { get; private set; }

        public UpdateDistanceMessage(int distance)
        {
            Distance = distance;
        }
    }
}