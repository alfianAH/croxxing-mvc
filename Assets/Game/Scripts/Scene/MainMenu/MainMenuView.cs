using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic;
using Croxxing.Module.Scene.Gameplay.Audios.SoundEffect;
using Croxxing.Module.Scene.MainMenu.GameSettings;
using Croxxing.Module.Scene.MainMenu.Menu;

namespace Croxxing.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        public MenuView menuView;
        public GameSettingsView gameSettingsView;
        public SoundEffectView soundEffectView;
        public BackgroundMusicView backgroundMusicView;
    }
}
