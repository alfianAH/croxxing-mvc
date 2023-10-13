using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Utility;
using UnityEngine;
using UnityEngine.Audio;

namespace Croxxing.Module.Scene.MainMenu.AudioSetting
{
    public class AudioSettingController: ObjectController<AudioSettingController, AudioSettingModel, IAudioSettingModel, AudioSettingView>
    {
        public void Init(AudioSettingModel model, AudioSettingView view)
        {
            _model = model;
            _view = view;
            SetView(view);

            LoadAudioMixer();
            SetAudioMixerVolume();
        }

        private void LoadAudioMixer()
        {
            AudioMixer audioMixer = Resources.Load<AudioMixer>("Audio Mixer/MasterAudioMixer");
            _model.SetAudioMixer(audioMixer);
        }

        public override void SetView(AudioSettingView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnVolumeChanged);
        }

        private void SetAudioMixerVolume()
        {
            float volume = AudioVolume.ConvertSliderValueToMixerValue(_model.Volume);
            _model.AudioMixer.SetFloat(_model.ParameterName, volume);
        }

        private void OnVolumeChanged(float value)
        {
            _model.SetVolume(value);
            SetAudioMixerVolume();
            Publish(new UpdateVolumeMessage(_model.Name, _model.Volume));
        }
    }
}