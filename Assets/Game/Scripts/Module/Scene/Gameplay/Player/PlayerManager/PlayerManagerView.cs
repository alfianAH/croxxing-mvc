using Agate.MVC.Base;
using Croxxing.Module.Global.ControlsData;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public class PlayerManagerView : ObjectView<IPlayerManagerModel>
    {
        [Range(0f, 10f)]
        [SerializeField] private float _playerSpeed = 8f;

        private Transform _playerTransform;
        private Rigidbody2D _playerRigidbody;
        private Action _moveUpAction, _moveDownAction, _moveLeftAction, _moveRightAction;
        
        public float PlayerSpeed => _playerSpeed;
        public Transform PlayerTransform => _playerTransform;
        public Rigidbody2D PlayerRigidbody => _playerRigidbody;

        public void SetCallbacks(Action moveUpAction, Action moveDownAction, Action moveLeftAction, Action moveRightAction)
        {
            _moveUpAction = moveUpAction;
            _moveDownAction = moveDownAction;
            _moveLeftAction = moveLeftAction;
            _moveRightAction = moveRightAction;
        }

        private void Start()
        {
            _playerTransform = GetComponent<Transform>();
            _playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_model == null) return;

            /*if (Input.GetKey(_model.ControlsData.MoveUp))
            {
                _moveUpAction?.Invoke();
            }

            if (Input.GetKey(_model.ControlsData.MoveDown))
            {
                _moveDownAction?.Invoke();
            }

            if (Input.GetKey(_model.ControlsData.MoveLeft))
            {
                _moveLeftAction?.Invoke();
            }

            if (Input.GetKey(_model.ControlsData.MoveRight))
            {
                _moveRightAction?.Invoke();
            }*/
        }

        protected override void InitRenderModel(IPlayerManagerModel model) { }

        protected override void UpdateRenderModel(IPlayerManagerModel model) { }
    }
}