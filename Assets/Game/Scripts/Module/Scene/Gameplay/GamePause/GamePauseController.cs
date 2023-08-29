using Agate.MVC.Base;
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