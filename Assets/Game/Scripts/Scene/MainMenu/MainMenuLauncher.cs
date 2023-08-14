using Croxxing.Boot;
using Croxxing.Utility;

namespace Croxxing.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName => GameScenes.MAIN_MENU;
    }
}
