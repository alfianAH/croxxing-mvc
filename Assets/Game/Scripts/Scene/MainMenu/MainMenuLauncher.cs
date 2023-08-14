using Croxxing.Boot;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName => GameScenes.MAIN_MENU;

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickPlayButton, OnClickCreditsButton);
            yield return null;
        }

        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene(GameScenes.GAMEPLAY);
        }

        private void OnClickCreditsButton()
        {
            SceneLoader.Instance.LoadScene(GameScenes.CREDITS);
        }
    }
}
