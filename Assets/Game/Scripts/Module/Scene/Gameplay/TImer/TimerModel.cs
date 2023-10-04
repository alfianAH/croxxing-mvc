using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Timer
{
    public class TimerModel: BaseModel, ITimerModel
    {
        public long Duration { get; private set; }
        public long StartTime { get; private set; }
        public long Passed { get; private set; }
        public long Remaining { get; private set; }
        public float Progress { get; private set; }
        public bool IsStarted { get; private set; }
        public bool IsCompleted { get; private set; }

        public TimerModel() { }
        public TimerModel(int second)
        {
            Duration = second * 1000;
        }

        public void StartCountdown(long currentTime)
        {
            StartTime = currentTime;
            IsStarted = true;
            IsCompleted = false;
            UpdateCountdown(currentTime);
            SetDataAsDirty();
        }

        public void UpdateCountdown(long currentTime)
        {
            if (IsStarted && !IsCompleted)
            {
                Passed = currentTime - StartTime;
                Remaining = Passed >= Duration ? 0 : Duration - Passed;
                Progress = Mathf.Clamp01(Mathf.Abs(
                    (Passed - (float)Duration) / Duration
                ));
                IsCompleted = Remaining == 0;
                SetDataAsDirty();
            }
        }
    }
}