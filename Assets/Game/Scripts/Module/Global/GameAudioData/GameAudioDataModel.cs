using Agate.MVC.Base;

namespace Croxxing.Module.Global.GameAudioData
{
    public class GameAudioDataModel: BaseModel, IGameAudioDataModel
    {
        public GameAudio GameAudioData { get; private set; }

        public void SetGameAudio(GameAudio volume)
        {
            GameAudioData = volume;
            SetDataAsDirty();
        }

        public void SetBgmVolume(float bgmVolume)
        {
            GameAudioData.BgmVolume = bgmVolume;
            SetDataAsDirty();
        }

        public void SetSfxVolume(float sfxVolume)
        {
            GameAudioData.SfxVolume = sfxVolume;
            SetDataAsDirty();
        }
    }
}