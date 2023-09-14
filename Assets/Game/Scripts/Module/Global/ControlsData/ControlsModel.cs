using Agate.MVC.Base;

namespace Croxxing.Module.Global.ControlsData
{
    public class ControlsModel : BaseModel, IControlsModel
    {
        public Controls ControlsData { get; private set; }

        public void SetControls(Controls controlsData)
        {
            ControlsData = controlsData;
            SetDataAsDirty();
        }

        public void ChangeBinding(int index, Binding binding)
        {
            ControlsData.bindings[index] = binding;
            SetDataAsDirty();
        }
    }
}