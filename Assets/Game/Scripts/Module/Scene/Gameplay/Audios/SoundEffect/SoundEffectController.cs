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
            AudioClip audioClip = GetAudioClip(audioName);

            audioSource.PlayOneShot(audioClip);
            _view.StopAudioCoroutine(audioSource);
        }

        private void LoadAudioMixer()
        {
            AudioMixerGroup audioMixerGroup = Resources.Load<AudioMixerGroup>("Audio Mixer/SoundEffectAudioMixer");
            _model.SetSoundEffectMixer(audioMixerGroup);
        }

        /// <summary>
        /// Get audio clip from audio name
        /// </summary>
        /// <param name="audioName">Audio name</param>
        /// <returns>Audio clip of audio name</returns>
        private AudioClip GetAudioClip(string audioName)
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
            if (soundEffect != null) return soundEffect.Clip;

            Debug.LogError($"Audio clip: {audioName} not available");
            return null;
        }

        /// <summary>
        /// Get audio source in object pooling
        /// </summary>
        /// <returns>Available sound effect audio source</returns>
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