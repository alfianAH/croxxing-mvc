using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Croxxing.Module.Scene.Gameplay.Audios.SoundEffect
{
    public class SoundEffectModel: BaseModel
    {
        public List<AudioSource> AudioSourcePool { get; private set; } = new List<AudioSource>();
        public SoundEffectScriptableObject SoundEffect { get; private set; }
        public AudioMixerGroup SoundEffectMixerGroup { get; private set; }

        public void AddAudioSource(AudioSource audioSource)
        {
            AudioSourcePool.Add(audioSource);
            SetDataAsDirty();
        }

        public void SetSoundEffect(SoundEffectScriptableObject soundEffect)
        {
            SoundEffect = soundEffect;
            SetDataAsDirty();
        }

        public void SetSoundEffectMixerGroup(AudioMixerGroup soundEffectMixer)
        {
            SoundEffectMixerGroup = soundEffectMixer;
            SetDataAsDirty();
        }
    }
}