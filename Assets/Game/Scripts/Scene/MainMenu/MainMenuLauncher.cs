using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.MainMenu.Menu;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName => GameScenes.MAIN_MENU;

        private MenuController _menuController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new MenuController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _menuController.SetView(_view.menuView);

            yield return base.InitSceneObject();
        }
    }
}
