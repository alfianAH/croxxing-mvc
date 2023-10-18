using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Credits.GameCredits;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.Credits
{
    public class CreditsLauncher : SceneLauncher<CreditsLauncher, CreditsView>
    {
        public override string SceneName => GameScenes.CREDITS;

        private GameCreditsController _gameCreditsController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new GameCreditsController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _gameCreditsController.SetView(_view.gameCreditsView);

            yield return base.InitSceneObject();
        }
    }
}
