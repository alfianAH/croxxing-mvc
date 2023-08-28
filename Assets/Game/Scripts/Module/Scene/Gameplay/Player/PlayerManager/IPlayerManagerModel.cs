using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public interface IPlayerManagerModel: IBaseModel
    {
        public float Speed { get; }
    }
}