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

        public override void SetView(RoadView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPlayerEnterRandomRoad);
        }

        public void SetRoadProperties(bool isActive, Vector3 position, RoadLane roadLane)
        {
            _model.SetCurrentlyActive(isActive);
            _model.SetPosition(position);
            _model.SetRoadLane(roadLane);
        }

        private void OnPlayerEnterRandomRoad()
        {
            _model.SetIsPlayerOnRoad(true);
            // Add score and distance
        }
    }
}