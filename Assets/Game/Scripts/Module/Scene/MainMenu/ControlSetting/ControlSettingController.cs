using Agate.MVC.Base;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public class ControlSettingController: ObjectController<ControlSettingController, ControlSettingModel, IControlSetting, ControlSettingView>
    {
        private InputAction _inputAction;
        private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

        public void Init(ControlSettingModel model, ControlSettingView view)
        {
            _model = model;
            _view = view;
            SetView(view);

            UpdateBehaviour();
        }

        public override void SetView(ControlSettingView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickRebind, OnClickReset);
        }

        private void UpdateBehaviour()
        {
            GetPlayerInput();
            UpdateBindingDisplayUI();
        }

        private void GetPlayerInput()
        {
            _inputAction = _model.PlayerInputController.InputManager.FindAction(_model.ActionName);
        }

        /// <summary>
        /// Return the action and binding index for the binding that is targeted by the component
        /// according to
        /// </summary>
        /// <param name="bindingIndex"></param>
        /// <returns></returns>
        private bool ResolveActionAndBinding(out int bindingIndex)
        {
            bindingIndex = -1;

            if (_inputAction == null)
                return false;

            if (string.IsNullOrEmpty(_model.ActionBindId))
                return false;

            // Look up binding index.
            var bindingId = new Guid(_model.ActionBindId);
            bindingIndex = _inputAction.bindings.IndexOf(x => x.id == bindingId);
            if (bindingIndex == -1)
            {
                Debug.LogError($"Cannot find binding with ID '{bindingId}' on '{_inputAction}'");
                return false;
            }

            return true;
        }

        private void OnClickRebind()
        {
            if (!ResolveActionAndBinding(out int bindingIndex))
                return;

            if (_inputAction.bindings[bindingIndex].isComposite)
            {
                int firstPartIndex = bindingIndex + 1;
                if (firstPartIndex < _inputAction.bindings.Count && _inputAction.bindings[firstPartIndex].isPartOfComposite)
                    PerformInteractiveRebind(firstPartIndex, allCompositeParts: true);
            }
            else
            {
                PerformInteractiveRebind(bindingIndex);
            }
        }

        private void PerformInteractiveRebind(int bindingIndex, bool allCompositeParts = false)
        {
            _inputAction.Disable();
            _rebindOperation?.Cancel();

            _rebindOperation = _inputAction.PerformInteractiveRebinding(bindingIndex)
                .OnCancel(operation => RebindCompleted())
                .OnComplete(operation =>
                {
                    RebindCompleted();

                    // If there's more composite parts we should bind, initiate a rebind
                    // for the next part.
                    if (allCompositeParts)
                    {
                        int nextBindingIndex = bindingIndex + 1;
                        if (nextBindingIndex < _inputAction.bindings.Count && _inputAction.bindings[nextBindingIndex].isPartOfComposite)
                            PerformInteractiveRebind(nextBindingIndex, true);
                    }
                });

            _view.ToggleActionRebindButtonState(false);
            _view.ToggleActionResetButtonState(false);
            _view.ToggleListeningPanelState(true);
            
            string partName = string.Empty;
            if (_inputAction.bindings[bindingIndex].isPartOfComposite)
                partName = $"Binding '{_inputAction.bindings[bindingIndex].name}'. ";

            _model.SetCurrentAction(partName);
            _rebindOperation.Start();
        }

        private void RebindCompleted()
        {
            _inputAction.Enable();
            _rebindOperation.Dispose();
            _rebindOperation = null;

            _model.SetCurrentAction("Input...");
            _view.ToggleActionRebindButtonState(true);
            _view.ToggleActionResetButtonState(true);
            _view.ToggleListeningPanelState(false);

            UpdateBindingDisplayUI();
        }

        private void OnClickReset()
        {
            if (!ResolveActionAndBinding(out int bindingIndex))
                return;

            if (_inputAction.bindings[bindingIndex].isComposite)
            {
                // It's a composite. Remove overrides from part bindings.
                for (int i = bindingIndex + 1; i < _inputAction.bindings.Count && _inputAction.bindings[i].isPartOfComposite; ++i)
                    _inputAction.RemoveBindingOverride(i);
            }
            else
            {
                _inputAction.RemoveBindingOverride(bindingIndex);
            }
            UpdateBindingDisplayUI();
        }

        private void UpdateBindingDisplayUI()
        {
            int bindingIndex = _inputAction.bindings.IndexOf(x => x.id.ToString() == _model.ActionBindId);
            string currentBindingInput = string.Empty;
            if (bindingIndex != -1)
                currentBindingInput = _inputAction.GetBindingDisplayString(bindingIndex);

            _model.SetActionBind(currentBindingInput);
        }
    }
}