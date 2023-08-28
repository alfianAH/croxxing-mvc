using Agate.MVC.Base;
using Croxxing.Module.Message;
using System.Collections;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Player.PlayerManager
{
    public class PlayerManagerController: ObjectController<PlayerManagerController, PlayerManagerModel, IPlayerManagerModel, PlayerManagerView>
    {
        private const float PLAYER_SPEED = 8F;

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _model.SetSpeed(PLAYER_SPEED);
        }

        public void Move(PlayerMovementMessage message)
        {
            _view.PlayerTransform.position = new Vector2(
                _view.PlayerTransform.position.x + message.InputAxis.x * Time.deltaTime * _model.Speed,
                _view.PlayerTransform.position.y + message.InputAxis.y * Time.deltaTime * _model.Speed
            );
        }
    }
}