using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Gameplay.TapAnywhereInput;
using Croxxing.Utility;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => GameScenes.GAMEPLAY;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new TapAnywhereController()
            };
        }
    }
}
