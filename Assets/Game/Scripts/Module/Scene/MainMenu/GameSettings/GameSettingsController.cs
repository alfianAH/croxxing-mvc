using Agate.MVC.Base;

namespace Croxxing.Module.Scene.MainMenu.GameSettings
{
    public class GameSettingsController : ObjectController<GameSettingsController, GameSettingsView>
    {
        public override void SetView(GameSettingsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickAudioMenuButton, OnClickControlsMenuButton);
        }

        private void OnClickAudioMenuButton()
        {
            _view.ActivateAudioMenu();
        }

        private void OnClickControlsMenuButton()
        {
            _view.ActivateControlsMenu();
        }
    }
}