using Agate.MVC.Base;

namespace Croxxing.Module.Global.GameAudioData
{
    public interface IGameAudioDataModel: IBaseModel
    {
        public GameAudio GameAudioData { get; }
    }
}