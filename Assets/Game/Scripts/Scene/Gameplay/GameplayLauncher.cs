using Agate.MVC.Base;
using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Gameplay.Player.PlayerManager;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using Croxxing.Utility;
using System.Collections;
using Croxxing.Module.Scene.Gameplay.Connector;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => GameScenes.GAMEPLAY;

        private StartCountdownController _startCountdownController;
        private PlayerManagerController _playerManagerController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new StartCountdownController(),
                new PlayerInputController(),
                new PlayerManagerController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _startCountdownController.SetView(_view.startCountdownView);
            _playerManagerController.SetView(_view.playerManagerView);

            yield return base.InitSceneObject();
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new StartCountdownConnector(),
                new PlayerManagerConnector(),
            };
        }
    }
}
