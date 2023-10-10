using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.GameOver
{
    public interface IGameOverModel: IBaseModel
    {
        public int Score { get; }
        public int HighScore { get; }
        public int Distance { get; }
        public int LongestDistance { get; }
    }
}