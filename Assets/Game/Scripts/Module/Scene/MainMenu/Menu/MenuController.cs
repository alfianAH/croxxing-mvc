using Agate.MVC.Base;
using Croxxing.Boot;
using Croxxing.Utility;

namespace Croxxing.Module.Scene.MainMenu.Menu
{
    public class MenuController: ObjectController<MenuController, MenuView>
    {
        public override void SetView(MenuView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickPlayButton, OnClickSettingsButton, OnClickCreditsButton, OnClickCloseSettingsButton);
        }

        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene(GameScenes.GAMEPLAY);
        }

        private void OnClickSettingsButton()
        {
            _view.SetActiveSettingPanel(true);
        }
       
        private void OnClickCreditsButton()
        {
            SceneLoader.Instance.LoadScene(GameScenes.CREDITS);
        }

        private void OnClickCloseSettingsButton()
        {
            _view.SetActiveSettingPanel(false);
        }
    }
}