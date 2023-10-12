using Agate.MVC.Base;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Croxxing.Module.Global.GameAudioData
{
    public class GameAudioDataController: DataController<GameAudioDataController, GameAudioDataModel, IGameAudioDataModel>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            Load();
        }

        public void SetBgmVolume(float bgmVolume)
        {
            _model.SetBgmVolume(bgmVolume);
        }

        public void SetSfxVolume(float sfxVolume)
        {
            _model.SetSfxVolume(sfxVolume);
        }

        public void SaveVolume()
        {
            Save();
        }

        private void Load()
        {
            string directory = Path.Combine(Application.persistentDataPath, "Save");
            string path = Path.Combine(directory, "GameAudio.json");

            if (File.Exists(path))
            {
                string gameAudioFile = File.ReadAllText(path);
                GameAudio gameAudioData = JsonUtility.FromJson<GameAudio>(gameAudioFile);
                _model.SetGameAudio(gameAudioData);
            }
            else
            {
                Directory.CreateDirectory(directory);
                InitGameAudio();
            }
        }

        private void InitGameAudio()
        {
            TextAsset initProgressFile = Resources.Load<TextAsset>("Data/GameAudio/InitialGameAudio");
            GameAudio initGameAudio = JsonUtility.FromJson<GameAudio>(initProgressFile.text);
            _model.SetGameAudio(initGameAudio);
            Save();
        }

        private void Save()
        {
            string path = $"{Application.persistentDataPath}/Save/GameAudio.json";
            string gameAudioData = JsonUtility.ToJson(_model.GameAudioData);
            File.WriteAllText(path, gameAudioData);
        }
    }
}