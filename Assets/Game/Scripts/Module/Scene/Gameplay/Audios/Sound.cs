using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios
{
    [Serializable]
    public class Sound
    {
        [SerializeField] private string name;
        [SerializeField] private AudioClip clip;

        [Range(0, 1)]
        [SerializeField] private float volume = 1;
        [Range(-3, 3)]
        [SerializeField] private float pitch = 1;

        public string Name => name;
        public AudioClip Clip => clip;
        public float Volume => volume;
        public float Pitch => pitch;
    }
}