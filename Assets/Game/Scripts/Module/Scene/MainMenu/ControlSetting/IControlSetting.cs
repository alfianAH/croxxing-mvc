using Agate.MVC.Base;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public interface IControlSetting: IBaseModel
    {
        public string ActionName { get; }
        public string ActionBind { get; }
        public string CurrentAction { get; }
    }
}