using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerMovement
{
    public interface IPlayerMovementModel: IBaseModel
    {
        public bool CanMove { get; }
        public float Speed { get; }
        public Controls ControlsData { get; }
    }
}