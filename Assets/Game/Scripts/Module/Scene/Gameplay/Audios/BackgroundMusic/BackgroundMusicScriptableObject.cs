using System;
using System.Collections.Generic;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic
{
    [Serializable]
    public class BackgroundMusicConfig: Sound
    {
        [SerializeField] private bool _isLoop = true;

        public bool IsLoop => _isLoop;
    }

    [CreateAssetMenu(fileName = "Background Music", menuName = "Scriptable Objects/Audio/BGM")]
    public class BackgroundMusicScriptableObject: ScriptableObject
    {
        [SerializeField] private List<BackgroundMusicConfig> _backgroundMusics;

        public List<BackgroundMusicConfig> BackgroundMusics => _backgroundMusics;
    }
}