using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Timer;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownModel: BaseModel
    {
        public TimerModel Timer { get; private set; }

        public void SetTimer(int second)
        {
            Timer = new TimerModel(second);
        }
    }
}
