using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownModel: BaseModel, IStartCountdownModel
    {
        public float Timer { get; private set; }

        public void SetTimer(float initTime)
        {
            Timer = initTime;
            SetDataAsDirty();
        }

        public void TimerCountdown()
        {
            Timer--;
            SetDataAsDirty();
        }
    }
}
