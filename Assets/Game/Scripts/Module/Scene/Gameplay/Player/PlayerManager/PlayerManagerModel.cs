using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public class PlayerManagerModel : BaseModel, IPlayerManagerModel
    {
        public float Speed { get; private set; }

        public void SetSpeed(float speed)
        {
            Speed = speed;
            SetDataAsDirty();
        }
    }
}