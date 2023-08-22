using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;
using Croxxing.Module.Message;
using System.Collections;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerMovement
{
    public class PlayerMovementController: ObjectController<PlayerMovementController, PlayerMovementModel, IPlayerMovementModel, PlayerMovementView>
    {
        private const float SPEED = 5f;
        private ControlsController _controlsController;

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _model.SetControls(_controlsController.Model.ControlsData);
        }

        public override void SetView(PlayerMovementView view)
        {
            base.SetView(view);
            view.SetCallbacks(MoveUp, MoveDown, MoveLeft, MoveRight);
        }

        public void OnStartPlay(StartPlayMessage message)
        {
            _model.SetSpeed(SPEED);
            _model.SetCanMove(true);
        }

        private void MoveUp()
        {
            Debug.Log("Move up");
        }

        private void MoveDown()
        {
            Debug.Log("Move down");
        }

        private void MoveLeft()
        {
            Debug.Log("Move left");
        }

        private void MoveRight()
        {
            Debug.Log("Move right");
        }
    }
}