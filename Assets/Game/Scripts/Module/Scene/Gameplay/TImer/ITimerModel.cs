using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.Timer
{
    public interface ITimerModel : IBaseModel
    {
        public long Remaining { get; }
        public float Progress { get; }
        public bool IsCompleted { get; }
    }
}