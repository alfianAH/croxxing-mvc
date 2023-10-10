using Agate.MVC.Base;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Croxxing.Module.Global.ProgressData
{
    public class ProgressDataController: DataController<ProgressDataController, ProgressDataModel, IProgressDataModel>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            Load();
        }

        public void SetHighScore(int highScore)
        {
            _model.SetHighScore(highScore);
        }

        public void SetLongestDistance(int longestDistance)
        {
            _model.SetLongestDistance(longestDistance);
        }

        public void SaveProgress()
        {
            Save();
        }

        private void Load()
        {
            string directory = Path.Combine(Application.persistentDataPath, "Save");
            string path = Path.Combine(directory, "Progress.json");

            if (File.Exists(path))
            {
                string progressFile = File.ReadAllText(path);
                Progress progressData = JsonUtility.FromJson<Progress>(progressFile);
                _model.SetProgressData(progressData);
            }
            else
            {
                Directory.CreateDirectory(directory);
                InitProgress();
            }
        }

        private void InitProgress()
        {
            TextAsset initProgressFile = Resources.Load<TextAsset>("Data/Progress/InitialProgress");
            Progress initProgress = JsonUtility.FromJson<Progress>(initProgressFile.text);
            _model.SetProgressData(initProgress);
            Save();
        }

        private void Save()
        {
            string path = $"{Application.persistentDataPath}/Save/Progress.json";
            string controlsData = JsonUtility.ToJson(_model.ProgressData);
            File.WriteAllText(path, controlsData);
        }
    }
}