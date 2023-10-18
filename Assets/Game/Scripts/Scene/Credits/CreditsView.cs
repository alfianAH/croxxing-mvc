using Agate.MVC.Base;
using Croxxing.Module.Scene.Credits.GameCredits;
using Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic;
using Croxxing.Module.Scene.Gameplay.Audios.SoundEffect;

namespace Croxxing.Scene.Credits
{
    public class CreditsView : BaseSceneView
    {
        public GameCreditsView gameCreditsView;
        public SoundEffectView soundEffectView;
        public BackgroundMusicView backgroundMusicView;
    }
}
