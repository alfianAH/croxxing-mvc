using Agate.MVC.Base;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public class PlayerManagerView : ObjectView<IPlayerManagerModel>
    {
        private Transform _playerTransform;
        private Rigidbody2D _playerRigidbody;
        private Action _playerMovement;
        
        public Transform PlayerTransform => _playerTransform;
        public Rigidbody2D PlayerRigidbody => _playerRigidbody;

        public void SetCallbacks(Action playerMovement)
        {
            _playerMovement = playerMovement;
        }

        private void Start()
        {
            _playerTransform = GetComponent<Transform>();
            _playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_model == null) return;
            _playerMovement?.Invoke();
        }

        protected override void InitRenderModel(IPlayerManagerModel model) { }

        protected override void UpdateRenderModel(IPlayerManagerModel model) { }
    }
}