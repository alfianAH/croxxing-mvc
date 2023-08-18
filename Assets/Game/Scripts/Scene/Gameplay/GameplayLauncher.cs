using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Gameplay.TapAnywhereInput;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => GameScenes.GAMEPLAY;

        private TapAnywhereController _tapAnywhereController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new TapAnywhereController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _tapAnywhereController.SetView(_view.tapAnywhereView);

            yield return base.InitSceneObject();
        }
    }
}
