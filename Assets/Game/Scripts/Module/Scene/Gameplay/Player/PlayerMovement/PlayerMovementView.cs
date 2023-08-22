using Agate.MVC.Base;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerMovement
{
    public class PlayerMovementView : ObjectView<IPlayerMovementModel>
    {
        private Action _moveUpAction, _moveDownAction, _moveLeftAction, _moveRightAction;

        public void SetCallbacks(Action moveUpAction, Action moveDownAction, Action moveLeftAction, Action moveRightAction)
        {
            _moveUpAction = moveUpAction;
            _moveDownAction = moveDownAction;
            _moveLeftAction = moveLeftAction;
            _moveRightAction = moveRightAction;
        }

        private void Update()
        {
            if (_model == null) return;
            if (!_model.CanMove) return;

            if (Input.GetKeyDown(KeyCode.W))
            {
                _moveUpAction?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _moveDownAction?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _moveLeftAction?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _moveRightAction?.Invoke();
            }
        }

        protected override void InitRenderModel(IPlayerMovementModel model)
        {
            
        }

        protected override void UpdateRenderModel(IPlayerMovementModel model)
        {
            
        }
    }
}