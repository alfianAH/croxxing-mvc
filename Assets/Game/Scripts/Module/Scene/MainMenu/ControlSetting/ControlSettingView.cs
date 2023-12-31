using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.MainMenu.ControlSetting
{
    public class ControlSettingView : ObjectView<IControlSetting>
    {
        [Header("Buttons")]
        [SerializeField] private Button _actionRebindButton;
        [SerializeField] private Button _actionResetButton;

        [Header("Action Text")]
        [SerializeField] private Text _actionNameText;
        
        [Header("Binding Text")]
        [SerializeField] private Text _actionBindText;

        [Header("Listening Panel")]
        [SerializeField] private GameObject _listeningPanel;
        [SerializeField] private Text _listeningText;

        public void SetCallbacks(UnityAction onClickActionRebind, UnityAction onClickActionReset)
        {
            _actionRebindButton.onClick.RemoveAllListeners();
            _actionRebindButton.onClick.AddListener(onClickActionRebind);

            _actionResetButton.onClick.RemoveAllListeners();
            _actionResetButton.onClick.AddListener(onClickActionReset);
        }

        public void ToggleActionRebindButtonState(bool newState)
        {
            ToggleGameObjectState(_actionRebindButton.gameObject, newState);
        }

        public void ToggleActionResetButtonState(bool newState)
        {
            ToggleGameObjectState(_actionResetButton.gameObject, newState);
        }

        public void ToggleListeningPanelState(bool newState)
        {
            ToggleGameObjectState(_listeningPanel, newState);
        }
        
        private void ToggleGameObjectState(GameObject targetGameObject, bool newState)
        {
            targetGameObject.SetActive(newState);
        }

        private void UpdateActionText(IControlSetting model)
        {
            _actionNameText.text = model.ActionName;
            _actionBindText.text = model.ActionBind;
            _listeningText.text = model.CurrentAction;
        }

        protected override void InitRenderModel(IControlSetting model)
        {
            UpdateActionText(model);
        }

        protected override void UpdateRenderModel(IControlSetting model)
        {
            UpdateActionText(model);
        }
    }
}