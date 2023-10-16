using Agate.MVC.Base;

namespace Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic
{
    public class BackgroundMusicModel: BaseModel
    {
        public BackgroundMusicScriptableObject BackgroundMusic { get; private set; }

        public void SetBackgroundMusic(BackgroundMusicScriptableObject backgroundMusic)
        {
            BackgroundMusic = backgroundMusic;
            SetDataAsDirty();
        }
    }
}