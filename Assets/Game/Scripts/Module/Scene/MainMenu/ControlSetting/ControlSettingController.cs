using Agate.MVC.Base;
using Croxxing.Module.Scene.MainMenu.GameSettings;
using System.Collections;
using UnityEngine.InputSystem;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public class ControlSettingController: ObjectController<ControlSettingController, ControlSettingModel, IControlSetting, ControlSettingView>
    {
        private GameSettingsController _gameSettingsController;
        private InputAction _inputAction;
        private PlayerInput _playerInput;
        private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

        public void Init(ControlSettingModel model, ControlSettingView view)
        {
            _model = model;
            _view = view;
            SetView(view);
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _playerInput = _gameSettingsController.GetPlayerInput();
        }

        public override void SetView(ControlSettingView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickRebind, OnClickReset);
        }

        public void UpdateBehaviour()
        {
            GetPlayerInput();
            UpdateBindingDisplayUI();
        }

        private void GetPlayerInput()
        {
            _inputAction = _playerInput.actions.FindAction(_model.ActionName);
        }

        private void OnClickRebind()
        {
            _view.ToggleActionRebindButtonState(false);
            _view.ToggleActionResetButtonState(false);
            _view.ToggleListeningPanelState(true);

            _rebindOperation = _inputAction.PerformInteractiveRebinding()
                .WithControlsExcluding("<Mouse>/position")
                .WithControlsExcluding("<Mouse>/delta")
                .WithControlsExcluding("<Gamepad>/Start")
                .WithControlsExcluding("<Keyboard>/p")
                .WithControlsExcluding("<Keyboard>/escape")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation => RebindCompleted());

            _rebindOperation.Start();
        }

        private void RebindCompleted()
        {
            _rebindOperation.Dispose();
            _rebindOperation = null;

            _view.ToggleActionRebindButtonState(true);
            _view.ToggleActionResetButtonState(true);
            _view.ToggleListeningPanelState(false);

            UpdateBindingDisplayUI();
        }

        private void OnClickReset()
        {
            InputActionRebindingExtensions.RemoveAllBindingOverrides(_inputAction);
            UpdateBindingDisplayUI();
        }

        private void UpdateBindingDisplayUI()
        {
            int controlBindingIndex = _inputAction.GetBindingIndexForControl(_inputAction.controls[0]);
            string currentBindingInput = InputControlPath.ToHumanReadableString(
                _inputAction.bindings[controlBindingIndex].effectivePath,
                InputControlPath.HumanReadableStringOptions.OmitDevice);

            _model.SetActionBind(currentBindingInput);
        }
    }
}