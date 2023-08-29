using Agate.MVC.Base;
using Croxxing.Module.Message;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.GamePause
{
    public class GamePauseController: ObjectController<GamePauseController, GamePauseView>
    {
        public override void SetView(GamePauseView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPause, OnResume);
        }

        public void OnGamePauseFromInput(GamePausedMessage message)
        {
            OnPause();
        }

        public void OnGameResumeFromInput(GameResumeMessage message)
        {
            OnResume();
        }

        private void OnPause()
        {
            Time.timeScale = 0.0f;
            _view.ActivatePausePanel();
        }

        private void OnResume()
        {
            Time.timeScale = 1.0f;
            _view.DeactivatePausePanel();
        }
    }
}