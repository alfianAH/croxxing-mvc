using Agate.MVC.Base;

namespace Croxxing.Module.Global.ProgressData
{
    public interface IProgressDataModel: IBaseModel
    {
        public Progress ProgressData { get; }
    }
}