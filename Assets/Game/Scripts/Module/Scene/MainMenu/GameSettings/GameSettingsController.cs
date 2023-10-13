using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;
using Croxxing.Module.Global.GameAudioData;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.MainMenu.AudioSetting;
using Croxxing.Module.Scene.MainMenu.ControlSetting;
using Croxxing.Utility;
using UnityEngine;

namespace Croxxing.Module.Scene.MainMenu.GameSettings
{
    public class GameSettingsController : ObjectController<GameSettingsController, GameSettingsView>
    {
        private PlayerInputController _playerInputController;
        private ControlsController _controlsController;
        private GameAudioDataController _gameAudioDataController;

        public override void SetView(GameSettingsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickAudioMenuButton, OnClickControlsMenuButton, OnSceneStart);
        }

        private void OnSceneStart()
        {
            AddControlAction("Move");
            AddControlAction("Pause");
            AddAudioSetting(AudioVolume.BGM_VOLUME_TYPE, AudioVolume.BGM_PARAMETER_NAME);
            AddAudioSetting(AudioVolume.SFX_VOLUME_TYPE, AudioVolume.SFX_PARAMETER_NAME);
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

        private void AddAudioSetting(string audioName, string audioParameterName)
        {
            AudioSettingModel model = new AudioSettingModel();
            model.SetName(audioName);
            model.SetParameterName(audioParameterName);

            GameObject duplicateAudioSettingView = _view.DuplicateAudioSettingObject();
            AudioSettingView audioSettingView = duplicateAudioSettingView.GetComponent<AudioSettingView>();

            AudioSettingController audioSettingController = new AudioSettingController();
            InjectDependencies(audioSettingController);

            switch (audioName)
            {
                case AudioVolume.BGM_VOLUME_TYPE:
                    model.SetVolume(_gameAudioDataController.Model.GameAudioData.BgmVolume);
                    break;

                case AudioVolume.SFX_VOLUME_TYPE:
                    model.SetVolume(_gameAudioDataController.Model.GameAudioData.SfxVolume);
                    break;

                default: break;
            }

            audioSettingController.Init(model, audioSettingView);
        }
    }
}