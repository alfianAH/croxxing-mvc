using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Player.PlayerMovement;
using Croxxing.Module.Scene.Gameplay.TapAnywhereInput;

namespace Croxxing.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        public TapAnywhereView tapAnywhereView;
        public PlayerMovementView playerMovementView;
    }
}
