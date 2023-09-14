using Agate.MVC.Base;
using Croxxing.Module.Message;
using System.Collections;
using System.Collections.Generic;
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

        public void SetControlsData(UpdateControlsMessage message)
        {
            Controls savedControls = JsonUtility.FromJson<Controls>(message.ActionJson);
            List<Binding> modelBindings = _model.ControlsData.bindings;

            if (savedControls == null)
            {
                Debug.LogError($"UpdateControlsMessage: '{message.ActionJson}'");
                return;
            }

            foreach (Binding savedBinding in savedControls.bindings)
            {
                for(int i=0 ; i < modelBindings.Count; i++)
                {
                    if (savedBinding.id == modelBindings[i].id)
                    {
                        _model.ChangeBinding(i, savedBinding);
                    }
                }
            }

            Save();
        }

        private void Load()
        {
            string directory = Path.Combine(Application.persistentDataPath, "Save");
            string path = Path.Combine(directory, "Controls.json");

            if (File.Exists(path))
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
            Controls initControls = JsonUtility.FromJson<Controls>(initControlsFile.text);
            _model.SetControls(initControls);
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