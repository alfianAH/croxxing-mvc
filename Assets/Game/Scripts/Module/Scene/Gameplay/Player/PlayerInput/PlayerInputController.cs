using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerInput
{
    public class PlayerInputController: BaseController<PlayerInputController>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();

        public void OnStartPlay(StartPlayMessage message)
        {
            _inputActionsManager.Player.Enable();
            _inputActionsManager.Player.Move.performed += Move;
        }

        private void Move(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Vector2 inputAxis = context.ReadValue<Vector2>();
                Publish(new PlayerMovementMessage(inputAxis));
            }
        }
    }
}