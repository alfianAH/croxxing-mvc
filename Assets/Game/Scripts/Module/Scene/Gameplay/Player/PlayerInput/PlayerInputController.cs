using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.InputSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerInput
{
    public class PlayerInputController: BaseController<PlayerInputController>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputActionsManager.UI.Enable();
            _inputActionsManager.UI.TapAnywhere.performed += OnTapAnywhere;
        }

        public void OnStartPlay(StartPlayMessage message)
        {
            _inputActionsManager.Player.Enable();
            _inputActionsManager.Player.Move.performed += OnMove;
            _inputActionsManager.Player.Move.canceled += OnMove;
        }

        private void OnTapAnywhere(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputActionsManager.UI.Disable();
                Publish(new TapAnywhereMessage());
            }
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed || context.canceled)
            {
                Vector2 inputAxis = context.ReadValue<Vector2>();
                Publish(new PlayerMovementMessage(inputAxis));
            }
        }
    }
}