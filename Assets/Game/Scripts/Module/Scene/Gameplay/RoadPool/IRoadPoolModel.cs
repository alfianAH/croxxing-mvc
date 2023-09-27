using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.RoadPool
{
    public interface IRoadPoolModel : IBaseModel
    {
        public bool IsPlaying { get; }
    }
}