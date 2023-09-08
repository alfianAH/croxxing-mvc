using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public class ControlSettingModel : BaseModel, IControlSetting
    {
        public string ActionName { get; private set; }
        public string ActionBind { get; private set; }
        public string CurrentAction { get; private set; }
        public string ActionBindId { get; private set; }
        public PlayerInputController PlayerInputController { get; private set; }

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

        public void SetPlayerInputController(PlayerInputController playerInputController)
        {
            PlayerInputController = playerInputController;
            SetDataAsDirty();
        }
    }
}
