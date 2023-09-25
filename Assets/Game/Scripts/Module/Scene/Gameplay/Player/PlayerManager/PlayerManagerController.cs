using Agate.MVC.Base;
using Croxxing.Module.Message;
using System.Collections;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public class PlayerManagerController: ObjectController<PlayerManagerController, PlayerManagerModel, IPlayerManagerModel, PlayerManagerView>
    {
        private Vector2 _rawInputMovement;
        private const float PLAYER_SPEED = 6.5F;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _model.SetSpeed(PLAYER_SPEED);
        }

        public override void SetView(PlayerManagerView view)
        {
            base.SetView(view);
            view.SetCallbacks(MoveThePlayer);
        }

        public void UpdateMovement(PlayerMovementMessage message)
        {
            _rawInputMovement = message.InputAxis;
        }

        public void UpdatePositionOnLastRoad(PlayerOnLastRoadMessage message)
        {
            _view.PlayerTransform.position = new Vector3(message.ResetPosition.x, message.ResetPosition.y);
        }

        private void MoveThePlayer()
        {
            Vector2 playerPosition = _view.PlayerTransform.position;
            _view.PlayerTransform.position = playerPosition + _model.Speed * Time.deltaTime * _rawInputMovement;
        }
    }
}