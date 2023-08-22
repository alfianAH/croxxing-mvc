using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerMovement
{
    public class PlayerMovementModel : BaseModel, IPlayerMovementModel
    {
        public bool CanMove { get; private set; }
        public float Speed { get; private set; }
        public Controls ControlsData { get; private set; }

        public void SetCanMove(bool canWalk)
        {
            CanMove = canWalk;
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
            SetDataAsDirty();
        }

        public void SetControls(Controls controls)
        {
            ControlsData = controls;
            SetDataAsDirty();
        }
    }
}