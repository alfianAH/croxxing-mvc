using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.InputSystem;
using System.Collections;
using UnityEngine.InputSystem;

namespace Croxxing.Module.Scene.Gameplay.TapAnywhereInput
{
    public class TapAnywhereController : BaseController<TapAnywhereController>
    {
        private InputActionManager _inputActionsManager = new InputActionManager();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputActionsManager.UI.Enable();
            _inputActionsManager.UI.TapAnywhere.performed += OnTapAnywhere;
        }

        public void OnTapAnywhere(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _inputActionsManager.UI.Disable();
                Publish(new TapAnywhereMessage());
            }
        }
    }
}
