using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadController: ObjectController<RoadController, RoadModel, IRoadModel, RoadView>
    {
        public void Init(RoadModel model, RoadView view)
        {
            _model = model;
            _view = view;
            SetView(view);
        }

        public void SetCurrentlyActive(bool isActive)
        {
            _model.SetCurrentlyActive(isActive);
            _view.gameObject.SetActive(isActive);
        }

        public void SetPosition(Vector3 position)
        {
            _model.SetPosition(position);
        }
    }
}