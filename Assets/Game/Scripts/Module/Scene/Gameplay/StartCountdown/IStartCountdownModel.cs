using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public interface IStartCountdownModel: IBaseModel
    {
        public long Remaining { get; }
        public float Progress { get; }
        public bool IsCompleted { get; }
    }
}