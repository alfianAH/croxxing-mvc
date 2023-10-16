using System;
using System.Collections.Generic;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios.SoundEffect
{
    [Serializable]
    public class SoundEffectConfig: Sound
    {

    }

    [CreateAssetMenu(fileName = "Sound Effect", menuName = "Scriptable Objects/Audio/SFX")]
    public class SoundEffectScriptableObject : ScriptableObject
    {
        [SerializeField] private List<SoundEffectConfig> _soundEffects;

        public List<SoundEffectConfig> SoundEffects => _soundEffects;
    }
}