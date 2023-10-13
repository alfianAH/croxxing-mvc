using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.MainMenu.AudioSetting
{
    public class AudioSettingView : ObjectView<IAudioSettingModel>
    {
        [SerializeField] private Text _audioSettingName;
        [SerializeField] private Slider _audioSettingSlider;

        public void SetCallbacks(UnityAction<float> onVolumeChanged)
        {
            _audioSettingSlider.onValueChanged.RemoveAllListeners();
            _audioSettingSlider.onValueChanged.AddListener(onVolumeChanged);
        }

        private void UpdateUI(IAudioSettingModel model)
        {
            _audioSettingName.text = model.Name;
            _audioSettingSlider.value = model.Volume;
        }

        protected override void InitRenderModel(IAudioSettingModel model)
        {
            UpdateUI(model);
        }

        protected override void UpdateRenderModel(IAudioSettingModel model)
        {
            UpdateUI(model);
        }
    }
}