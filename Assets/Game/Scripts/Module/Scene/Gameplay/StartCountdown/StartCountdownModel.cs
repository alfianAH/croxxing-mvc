using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownModel: BaseModel, IStartCountdownModel
    {
        public long Duration { get; private set; }
        public long StartTime { get; private set; }
        public long Passed { get; private set; }
        public long Remaining { get; private set; }
        public float Progress { get; private set; }
        public bool IsStarted { get; private set; }
        public bool IsCompleted { get; private set; }

        public StartCountdownModel(int second)
        {
            Duration = second * 1000;
        }

        public void StartTimer(long currentTime)
        {
            StartTime = currentTime;
            IsStarted = true;
            IsCompleted = false;
            UpdateTimer(currentTime);
            SetDataAsDirty();
        }

        public void UpdateTimer(long currentTime)
        {
            if(IsStarted && !IsCompleted)
            {
                Passed = currentTime - StartTime;
                Remaining = Passed >= Duration ? 0 : Duration - Passed;
                Progress = Mathf.Clamp01((float)Passed / (float)Duration);
                IsCompleted = Remaining == 0;
                SetDataAsDirty();
            }
        }
    }
}
