using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.HUD
{
    public class HUDModel : BaseModel, IHUDModel
    {
        public int Score { get; private set; }
        public int Distance { get; private set; }

        public void SetScore(int score)
        {
            Score = score;
            SetDataAsDirty();
        }

        public void SetDistance(int distance)
        {
            Distance = distance;
            SetDataAsDirty();
        }
    }
}