using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic
{
    [Serializable]
    public class BackgroundMusicConfig: Sound
    {
        [SerializeField] private bool _isLoop = true;

        public bool IsLoop => _isLoop;
    }
}