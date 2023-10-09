using Agate.MVC.Base;
using Agate.MVC.Core;
using Croxxing.Boot;
using Croxxing.Module.Scene.Gameplay.Player.PlayerManager;
using Croxxing.Module.Scene.Gameplay.Player.PlayerInput;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using Croxxing.Utility;
using System.Collections;
using Croxxing.Module.Scene.Gameplay.Connector;
using Croxxing.Module.Scene.Gameplay.GamePause;
using Croxxing.Module.Scene.MainMenu.GameSettings;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using Croxxing.Module.Scene.Gameplay.Road;
using Croxxing.Module.Scene.Gameplay.VehiclePool;
using Croxxing.Module.Scene.Gameplay.ScoreCalculator;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => GameScenes.GAMEPLAY;

        private StartCountdownController _startCountdownController;
        private PlayerManagerController _playerManagerController;
        private GamePauseController _gamePauseController;
        private GameSettingsController _gameSettingsController;
        private RoadPoolController _roadPoolController;
        private VehiclePoolController _vehiclePoolController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new StartCountdownController(),
                new PlayerInputController(),
                new PlayerManagerController(),
                new GamePauseController(),
                new GameSettingsController(),
                new RoadPoolController(),
                new VehiclePoolController(),
                new ScoreCalculatorController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _startCountdownController.SetView(_view.startCountdownView);
            _playerManagerController.SetView(_view.playerManagerView);
            _gamePauseController.SetView(_view.gamePauseView);
            _gameSettingsController.SetView(_view.gameSettingsView);
            _roadPoolController.SetView(_view.roadPoolView);
            _vehiclePoolController.SetView(_view.vehiclePoolView);

            yield return base.InitSceneObject();
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new StartCountdownConnector(),
                new PlayerManagerConnector(),
                new GamePauseConnector(),
                new ScoreCalculatorConnector(),
            };
        }
    }
}
