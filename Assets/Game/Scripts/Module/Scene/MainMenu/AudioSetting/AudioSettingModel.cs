using Agate.MVC.Base;
using UnityEngine.Audio;

namespace Croxxing.Module.Scene.MainMenu.AudioSetting
{
    public class AudioSettingModel: BaseModel, IAudioSettingModel
    {
        public string Name { get; private set; }
        public string ParameterName { get; private set; }
        public float Volume { get; private set; }
        public AudioMixer AudioMixer { get; private set; }

        public void SetName(string name)
        {
            Name = name;
            SetDataAsDirty();
        }

        public void SetParameterName(string parameterName)
        {
            ParameterName = parameterName;
            SetDataAsDirty();
        }

        public void SetVolume(float volume)
        {
            Volume = volume;
            SetDataAsDirty();
        }

        public void SetAudioMixer(AudioMixer audioMixer)
        {
            AudioMixer = audioMixer;
            SetDataAsDirty();
        }
    }
}