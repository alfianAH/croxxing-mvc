using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic;
using Croxxing.Module.Scene.Gameplay.Audios.SoundEffect;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.MainMenu.GameSettings;
using Croxxing.Module.Scene.MainMenu.Menu;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName => GameScenes.MAIN_MENU;

        private MenuController _menuController;
        private GameSettingsController _gameSettingsController;
        private SoundEffectController _soundEffectController;
        private BackgroundMusicController _backgroundMusicController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new MenuController(),
                new PlayerInputController(),
                new GameSettingsController(),
                new SoundEffectController(),
                new BackgroundMusicController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _menuController.SetView(_view.menuView);
            _gameSettingsController.SetView(_view.gameSettingsView);
            _soundEffectController.SetView(_view.soundEffectView);
            _backgroundMusicController.SetView(_view.backgroundMusicView);

            yield return base.InitSceneObject();
        }
    }
}
