using Agate.MVC.Base;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Croxxing.Module.Scene.Gameplay.Audios.SoundEffect
{
    public class SoundEffectController: ObjectController<SoundEffectController, SoundEffectModel, SoundEffectView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadAudioMixer();
        }

        public void Play(string audioName)
        {
            AudioSource audioSource = GetAudioSource();
            SoundEffectConfig soundEffect = GetSoundEffect(audioName);

            audioSource.volume = soundEffect.Volume;
            audioSource.pitch = soundEffect.Pitch;
            audioSource.PlayOneShot(soundEffect.Clip);
            _view.StopAudioCoroutine(audioSource);
        }

        private void LoadAudioMixer()
        {
            AudioMixerGroup audioMixerGroup = Resources.Load<AudioMixerGroup>("Audio Mixer/SoundEffectAudioMixer");
            _model.SetSoundEffectMixer(audioMixerGroup);
        }

        private SoundEffectConfig GetSoundEffect(string audioName)
        {
            SoundEffectConfig soundEffect = _view.SoundEffects.Find(
                s => {
                    if (s.Name.ToLower() == audioName.ToLower())
                    {
                        return true;
                    }
                    return false;
                }
            );
            if (soundEffect != null) return soundEffect;

            Debug.LogError($"Audio clip: {audioName} not available");
            return null;
        }

        private AudioSource GetAudioSource()
        {
            AudioSource audioSource = _model.AudioSourcePool.Find(source =>
                !source.isPlaying && !source.gameObject.activeInHierarchy);

            if (audioSource == null)
            {
                GameObject newAudioObject = new GameObject("Sound Effect", typeof(AudioSource));
                newAudioObject.transform.parent = _view.transform;

                // Set mixer
                audioSource = newAudioObject.GetComponent<AudioSource>();
                audioSource.outputAudioMixerGroup = _model.SoundEffectMixer;

                // Add to pool
                _model.AddAudioSource(audioSource);
            }

            audioSource.gameObject.SetActive(true);

            return audioSource;
        }
    }
}