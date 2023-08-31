using Agate.MVC.Base;
using Croxxing.Module.Scene.MainMenu.ControlSetting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Croxxing.Module.Scene.MainMenu.GameSettings
{
    public class GameSettingsController : ObjectController<GameSettingsController, GameSettingsView>
    {
        public override void SetView(GameSettingsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickAudioMenuButton, OnClickControlsMenuButton, OnSceneStart);
        }

        public PlayerInput GetPlayerInput()
        {
            return _view.PlayerInputSystem;
        }

        private void OnSceneStart()
        {
            AddControlAction("Move Up", "W");
            AddControlAction("Move Left", "A");
            AddControlAction("Move Down", "S");
            AddControlAction("Move Right", "D");
        }

        private void AddControlAction(string actionName, string actionBind)
        {
            ControlSettingModel controlSettingModel = new ControlSettingModel(actionName, actionBind);
            GameObject duplicateControlView = _view.DuplicateBindActionObject();
            ControlSettingView controlSettingView = duplicateControlView.GetComponent<ControlSettingView>();

            ControlSettingController controlSetting = new ControlSettingController();
            InjectDependencies(controlSetting);

            controlSetting.Init(controlSettingModel, controlSettingView);
        }

        private void OnClickAudioMenuButton()
        {
            _view.ActivateAudioMenu();
        }

        private void OnClickControlsMenuButton()
        {
            _view.ActivateControlsMenu();
        }
    }
}