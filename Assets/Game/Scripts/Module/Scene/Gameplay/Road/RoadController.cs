using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadController: ObjectController<RoadController, RoadModel, IRoadModel, RoadView>
    {
        private RoadPoolController _roadPoolController;

        public void Init(RoadModel model, RoadView view)
        {
            _model = model;
            _view = view;
            SetView(view);
        }

        public override void SetView(RoadView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPlayerEnterRandomRoad, OnPlayerEnterLastRoad);
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

        private void OnPlayerEnterLastRoad(float xAxis)
        {
            Vector2 resetPosition = new Vector2(xAxis, _roadPoolController.GetFirstLaneYAxis());
            Publish(new PlayerOnLastRoadMessage(resetPosition));
        }
    }
}