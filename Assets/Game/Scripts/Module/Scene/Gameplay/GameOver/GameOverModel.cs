using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.GameOver
{
    public class GameOverModel : BaseModel, IGameOverModel
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }
        public int Distance { get; private set; }
        public int LongestDistance { get; private set; }

        public void SetScore(int score)
        {
            Score = score;
            SetDataAsDirty();
        }

        public void SetHighScore(int highScore)
        {
            HighScore = highScore;
            SetDataAsDirty();
        }

        public void SetDistance(int distance)
        {
            Distance = distance;
            SetDataAsDirty();
        }

        public void SetLongestDistance(int longestDistance)
        {
            LongestDistance = longestDistance;
            SetDataAsDirty();
        }
    }
}