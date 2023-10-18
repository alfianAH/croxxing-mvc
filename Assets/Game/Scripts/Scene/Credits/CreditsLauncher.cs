using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Credits.GameCredits;
using Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic;
using Croxxing.Module.Scene.Gameplay.Audios.SoundEffect;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.Credits
{
    public class CreditsLauncher : SceneLauncher<CreditsLauncher, CreditsView>
    {
        public override string SceneName => GameScenes.CREDITS;

        private GameCreditsController _gameCreditsController;
        private SoundEffectController _soundEffectController;
        private BackgroundMusicController _backgroundMusicController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new GameCreditsController(),
                new SoundEffectController(),
                new BackgroundMusicController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _gameCreditsController.SetView(_view.gameCreditsView);
            _soundEffectController.SetView(_view.soundEffectView);
            _backgroundMusicController.SetView(_view.backgroundMusicView);

            yield return base.InitSceneObject();
        }
    }
}
