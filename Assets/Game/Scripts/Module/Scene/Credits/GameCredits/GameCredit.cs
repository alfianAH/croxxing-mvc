using System;
using System.Collections.Generic;

namespace Croxxing.Module.Scene.Credits.GameCredits
{
    [Serializable]
    public class GameCredit
    {
        public string title;
        public string[] body;
    }

    [Serializable]
    public class GameCreditsFull
    {
        public List<GameCredit> credits;
    }
}