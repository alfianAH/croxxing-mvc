using Agate.MVC.Base;
using Croxxing.Module.Message;

namespace Croxxing.Module.Scene.Gameplay.HUD
{
    public class HUDController: ObjectController<HUDController, HUDModel, IHUDModel, HUDView>
    {
        public void UpdateScore(UpdateScoreMessage message)
        {
            _model.SetScore(message.Score);
        }
    }
}