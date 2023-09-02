using Agate.MVC.Base;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public class ControlSettingModel : BaseModel, IControlSetting
    {
        public string ActionName { get; private set; }
        public string ActionBind { get; private set; }
        public string CurrentAction { get; private set; }
        public string ActionBindId { get; private set; }

        public ControlSettingModel() { }

        public ControlSettingModel(string actionName, string actionBind, string actionBindId)
        {
            ActionName = actionName;
            ActionBind = actionBind;
            ActionBindId = actionBindId;
            SetDataAsDirty();
        }

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

        public void SetCurrentAction(string currentAction)
        {
            CurrentAction = currentAction;
            SetDataAsDirty();
        }
    }
}
