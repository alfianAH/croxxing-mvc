using Agate.MVC.Base;

namespace Croxxing.Module.Global.ControlsData
{
    public interface IControlsModel: IBaseModel
    {
        public Controls ControlsData { get; }
    }
}