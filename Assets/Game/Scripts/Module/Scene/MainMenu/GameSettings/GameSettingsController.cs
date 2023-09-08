using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.MainMenu.ControlSetting;
using UnityEngine;

namespace Croxxing.Module.Scene.MainMenu.GameSettings
{
    public class GameSettingsController : ObjectController<GameSettingsController, GameSettingsView>
    {
        private PlayerInputController _playerInputController;

        public override void SetView(GameSettingsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickAudioMenuButton, OnClickControlsMenuButton, OnSceneStart);
        }

        private void OnSceneStart()
        {
            AddControlAction("Move", "W/A/S/D");
        }

        private void AddControlAction(string actionName, string actionBind)
        {
            string actionBindId = _playerInputController.InputManager.FindAction(actionName).bindings[0].id.ToString();
            ControlSettingModel controlSettingModel = new ControlSettingModel(actionName, actionBind, actionBindId);
            controlSettingModel.SetPlayerInputController(_playerInputController);

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