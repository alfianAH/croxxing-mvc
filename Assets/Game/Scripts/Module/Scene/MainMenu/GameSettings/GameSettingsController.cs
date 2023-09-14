using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.MainMenu.ControlSetting;
using UnityEngine;

namespace Croxxing.Module.Scene.MainMenu.GameSettings
{
    public class GameSettingsController : ObjectController<GameSettingsController, GameSettingsView>
    {
        private PlayerInputController _playerInputController;
        private ControlsController _controlsController;

        public override void SetView(GameSettingsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickAudioMenuButton, OnClickControlsMenuButton, OnSceneStart);
        }

        private void OnSceneStart()
        {
            AddControlAction("Move");
            AddControlAction("Pause");
        }

        private void AddControlAction(string actionName)
        {
            string actionBindId = _playerInputController.InputManager.FindAction(actionName).bindings[0].id.ToString();
            ControlSettingModel controlSettingModel = new ControlSettingModel(actionName, actionBindId);
            controlSettingModel.SetPlayerInputController(_playerInputController);

            GameObject duplicateControlView = _view.DuplicateBindActionObject();
            ControlSettingView controlSettingView = duplicateControlView.GetComponent<ControlSettingView>();

            ControlSettingController controlSetting = new ControlSettingController();
            InjectDependencies(controlSetting);

            string controlsJson = JsonUtility.ToJson(_controlsController.Model.ControlsData);

            controlSetting.Init(controlSettingModel, controlSettingView, controlsJson);
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