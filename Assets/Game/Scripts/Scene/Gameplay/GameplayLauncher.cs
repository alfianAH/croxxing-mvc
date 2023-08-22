using Agate.MVC.Base;
using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Global.ControlsData;
using Croxxing.Module.Scene.Gameplay.Player.PlayerMovement;
using Croxxing.Module.Scene.Gameplay.TapAnywhereInput;
using Croxxing.Utility;
using System.Collections;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => GameScenes.GAMEPLAY;

        private TapAnywhereController _tapAnywhereController;
        private PlayerMovementController _playerMovementController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new TapAnywhereController(),
                new PlayerMovementController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _tapAnywhereController.SetView(_view.tapAnywhereView);
            _playerMovementController.SetView(_view.playerMovementView);

            yield return base.InitSceneObject();
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new PlayerMovementConnector(),
            };
        }
    }
}
