using Agate.MVC.Base;
using Croxxing.Module.Message;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Croxxing.Module.Global.ControlsData
{
    public class ControlsController : DataController<ControlsController, ControlsModel, IControlsModel>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            Load();
        }

        public void SetMoveKeys(UpdateControlsMessage message)
        {
            _model.SetMoveUpKey(message.ControlsData.MoveUp);
            _model.SetMoveDownKey(message.ControlsData.MoveDown);
            _model.SetMoveLeftKey(message.ControlsData.MoveLeft);
            _model.SetMoveRightKey(message.ControlsData.MoveRight);
        }

        public void SaveControls()
        {
            Save();
        }

        private void Load()
        {
            string directory = Path.Combine(Application.persistentDataPath, "Save");
            string path = Path.Combine(directory, "Controls.json");
            
            if(File.Exists(path))
            {
                string controlsFile = File.ReadAllText(path);
                Controls controls = JsonUtility.FromJson<Controls>(controlsFile);
                _model.SetControls(controls);
            }
            else
            {
                Directory.CreateDirectory(directory);
                InitProgress();
            }
        }

        private void InitProgress()
        {
            TextAsset initControlsFile = Resources.Load<TextAsset>("Data/Controls/InitialControls");
            Controls controls = JsonUtility.FromJson<Controls>(initControlsFile.text);
            _model.SetControls(controls);
            Save();
        }

        private void Save()
        {
            string path = $"{Application.persistentDataPath}/Save/Controls.json";
            string controlsData = JsonUtility.ToJson(_model.ControlsData);
            File.WriteAllText(path, controlsData);
        }
    }
}