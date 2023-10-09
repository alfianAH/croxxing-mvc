using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.GamePause;
using Croxxing.Module.Scene.Gameplay.HUD;
using Croxxing.Module.Scene.Gameplay.Player.PlayerManager;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using Croxxing.Module.Scene.Gameplay.StartCountdown;
using Croxxing.Module.Scene.Gameplay.VehiclePool;
using Croxxing.Module.Scene.MainMenu.GameSettings;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public PlayerManagerView playerManagerView;
        public StartCountdownView startCountdownView;
        public GamePauseView gamePauseView;
        public GameSettingsView gameSettingsView;
        public RoadPoolView roadPoolView;
        public VehiclePoolView vehiclePoolView;
        public HUDView hudView;
    }
}
