using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Timer;
using System.Collections.Generic;

namespace Croxxing.Module.Scene.Credits.GameCredits
{
    public class GameCreditsModel: BaseModel, IGameCreditsModel
    {
        public int Index { get; private set; } = 0;
        public string Title { get; private set; }
        public string Body { get; private set; }
        public TimerModel Timer { get; private set; }
        public GameCreditsFull GameCredits { get; private set; }

        public void IncreaseIndex()
        {
            Index++;
            SetDataAsDirty();
        }

        public void SetTitle(string title)
        {
            Title = title;
            SetDataAsDirty();
        }

        public void SetBody(string body)
        {
            Body = body;
            SetDataAsDirty();
        }

        public void SetGameCredits(GameCreditsFull gameCredits)
        {
            GameCredits = gameCredits;
            SetDataAsDirty();
        }

        public void SetTimer(int second)
        {
            Timer = new TimerModel(second);
            SetDataAsDirty();
        }
    }
}