using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public interface IStartCountdownModel: IBaseModel
    {
        public float Timer { get; }
    }
}