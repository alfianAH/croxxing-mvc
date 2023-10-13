using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Croxxing.Module.Scene.Gameplay.Audios.SoundEffect
{
    public class SoundEffectView: BaseView
    {
        [SerializeField] private AudioMixerGroup _sfxAudioMixerGroup;
        [SerializeField] private List<SoundEffectConfig> _soundEffects;

        public AudioMixerGroup SfxAudioMixerGroup => _sfxAudioMixerGroup;
        public List<SoundEffectConfig> SoundEffects => _soundEffects;

        public void StopAudioCoroutine(AudioSource audioSource)
        {
            StartCoroutine(StopAudio(audioSource));
        }

        /// <summary>
        /// Deactivate audio's game object after not playing anymore
        /// </summary>
        /// <param name="audioSource">Current audio source</param>
        /// <returns></returns>
        private IEnumerator StopAudio(AudioSource audioSource)
        {
            yield return new WaitUntil(() => !audioSource.isPlaying);
            audioSource.gameObject.SetActive(false);
        }
    }
}