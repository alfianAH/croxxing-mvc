using Agate.MVC.Base;

namespace Croxxing.Module.Scene.MainMenu.AudioSetting
{
    public interface IAudioSettingModel : IBaseModel
    {
        public string Name { get; }
        public float Volume { get; }
    }
}