using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        private StartCountdownController _startCountdownController;

        public override string SceneName => GameScenes.GAMEPLAY;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new StartCountdownController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _startCountdownController.SetView(_view.startCountdownView);
            return base.InitSceneObject();
        }
    }
}
