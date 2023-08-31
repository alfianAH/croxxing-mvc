using Agate.MVC.Base;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public class ControlSettingModel : BaseModel, IControlSetting
    {
        public string ActionName { get; private set; }
        public string ActionBind { get; private set; }

        public void SetActionName(string actionName)
        {
            ActionName = actionName;
            SetDataAsDirty();
        }

        public void SetActionBind(string actionBind)
        {
            ActionBind = actionBind;
            SetDataAsDirty();
        }
    }
}
