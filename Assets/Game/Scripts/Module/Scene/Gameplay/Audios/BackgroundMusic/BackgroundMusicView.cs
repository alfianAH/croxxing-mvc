using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic
{
    public class BackgroundMusicView: BaseView
    {
        [SerializeField] private List<BackgroundMusicConfig> _backgroundMusics;

        public List<BackgroundMusicConfig> BackgroundMusics => _backgroundMusics;
    }
}