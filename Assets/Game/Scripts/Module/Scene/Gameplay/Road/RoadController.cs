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

        public void SetRoadProperties(Vector3 position, RoadLane roadLane)
        {
            _model.SetPosition(position);
            _model.SetRoadLane(roadLane);

            // Set road velocity
            float velocity = Random.Range(3, 10);
            _model.SetVehicleVelocity(velocity);
        }

        public void SetRoadActive(bool isActive)
        {
            _model.SetCurrentlyActive(isActive);
        }

        public void SetStartingSpawn()
        {
            if (_model.Type == RoadType.Sidewalk) return;

            int randomNumber = Random.Range(0, 10);

            if(randomNumber % 2 == 0)
            {
                _model.SetRoadStartingSpawn(RoadStartingSpawn.Right);

                Vector3 spawnerPosition = new Vector3(9, _model.Position.y);
                Vector3 despawnerPosition = new Vector3(-9, _model.Position.y);
                _model.SetSpawnerAndDespawnerPosition(spawnerPosition, despawnerPosition);
            }
            else
            {
                _model.SetRoadStartingSpawn(RoadStartingSpawn.Left);

                Vector3 spawnerPosition = new Vector3(-9, _model.Position.y);
                Vector3 despawnerPosition = new Vector3(9, _model.Position.y);
                _model.SetSpawnerAndDespawnerPosition(spawnerPosition, despawnerPosition);
            }
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