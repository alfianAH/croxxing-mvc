using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;
using Croxxing.Module.Message;
using System.Collections;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerMovement
{
    public class PlayerMovementController: ObjectController<PlayerMovementController, PlayerMovementModel, IPlayerMovementModel, PlayerMovementView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            Init();
        }

        public override void SetView(PlayerMovementView view)
        {
            base.SetView(view);
            view.SetCallbacks(MoveUp, MoveDown, MoveLeft, MoveRight);
        }

        public void OnStartPlay(StartPlayMessage message)
        {
            _model.SetSpeed(_view.PlayerSpeed);
            _model.SetCanMove(true);
        }

        private void Init()
        {
            Controls controls = new Controls();
            ControlsModel controlsModel = new ControlsModel();
            controlsModel.SetControls(controls);
            controlsModel.SetMoveUpKey(KeyCode.W);
            controlsModel.SetMoveLeftKey(KeyCode.A);
            controlsModel.SetMoveDownKey(KeyCode.S);
            controlsModel.SetMoveRightKey(KeyCode.D);

            _model.SetControls(controlsModel.ControlsData);
        }

        private void MoveUp()
        {
            _view.PlayerTransform.position = new Vector2(
                _view.PlayerTransform.position.x,
                _view.PlayerTransform.position.y + Time.deltaTime * _model.Speed
            );
        }

        private void MoveDown()
        {
            _view.PlayerTransform.position = new Vector2(
                _view.PlayerTransform.position.x,
                _view.PlayerTransform.position.y - Time.deltaTime * _model.Speed
            );
        }

        private void MoveLeft()
        {
            _view.PlayerTransform.position = new Vector2(
                _view.PlayerTransform.position.x - Time.deltaTime * _model.Speed,
                _view.PlayerTransform.position.y
            );
        }

        private void MoveRight()
        {
            _view.PlayerTransform.position = new Vector2(
                _view.PlayerTransform.position.x + Time.deltaTime * _model.Speed,
                _view.PlayerTransform.position.y
            );
        }
    }
}