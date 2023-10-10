using Agate.MVC.Base;

namespace Croxxing.Module.Global.ProgressData
{
    public class ProgressDataModel: BaseModel, IProgressDataModel
    {
        public Progress ProgressData { get; private set; }

        public void SetProgressData(Progress progressData)
        {
            ProgressData = progressData;
            SetDataAsDirty();
        }

        public void SetHighScore(int highScore)
        {
            ProgressData.HighScore = highScore;
            SetDataAsDirty();
        }

        public void SetLongestDistance(int longestDistance)
        {
            ProgressData.LongestDistance = longestDistance;
            SetDataAsDirty();
        }
    }
}