namespace Croxxing.Module.Message
{
    public struct AddScoreMessage
    {
        public int AdditionalScore { get; private set; }

        public AddScoreMessage(int additionalScore) 
        { 
            AdditionalScore = additionalScore; 
        }
    }
}