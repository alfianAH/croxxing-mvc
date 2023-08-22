using Agate.MVC.Base;
using UnityEngine;

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

        public void SetMoveUpKey(KeyCode moveUp)
        {
            ControlsData.MoveUp = moveUp;
            SetDataAsDirty();
        }

        public void SetMoveDownKey(KeyCode moveDown)
        {
            ControlsData.MoveDown = moveDown;
            SetDataAsDirty();
        }

        public void SetMoveLeftKey(KeyCode moveLeft)
        {
            ControlsData.MoveLeft = moveLeft;
            SetDataAsDirty();
        }

        public void SetMoveRightKey(KeyCode moveRight)
        {
            ControlsData.MoveRight = moveRight;
            SetDataAsDirty();
        }
    }
}