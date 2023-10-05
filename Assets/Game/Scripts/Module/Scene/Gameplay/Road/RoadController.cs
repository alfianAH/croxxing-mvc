using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using Croxxing.Module.Scene.Gameplay.Timer;
using Croxxing.Module.Scene.Gameplay.VehiclePool;
using Croxxing.Utility;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadController: ObjectController<RoadController, RoadModel, IRoadModel, RoadView>
    {
        private RoadPoolController _roadPoolController;
        private VehiclePoolController _vehiclePoolController;

        public void Init(RoadModel model, RoadView view, TimerView timer)
        {
            _model = model;
            _view = view;
            SetView(view);

            SetSpawnRange();
            timer.SetModel(_model.Timer);
            timer.Init(TickTimer);
            StartTimer();
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
            float velocity = Random.Range(3, 5);
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

        public void SetSpawnRange()
        {
            if(_model.Type == RoadType.Sidewalk) return;

            _model.SetSpawnRange(Random.Range(1, 3));
            _model.SetTimer(_model.SpawnRange);
        }

        private void StartTimer()
        {
            if (_model.Type == RoadType.Sidewalk) return;

            _model.Timer.StartCountdown(GameUtils.GetCurrentTime());
        }

        private void TickTimer()
        {
            if (_model.Type == RoadType.Sidewalk) return;

            long currentTime = GameUtils.GetCurrentTime();
            _model.Timer.UpdateCountdown(currentTime);

            if (_model.Timer.IsCompleted)
            {
                // Spawn vehicle
                _vehiclePoolController.SpawnVehicleOnRoad(this);

                // Restart time
                _model.Timer.StartCountdown(currentTime);
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