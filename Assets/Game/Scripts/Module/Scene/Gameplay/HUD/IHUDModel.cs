using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.HUD
{
    public interface IHUDModel: IBaseModel
    {
        public int Score { get; }
        public int Distance { get; }
    }
}