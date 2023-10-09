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

        private TimerView _timerView;

        public void Init(RoadModel model, RoadView view, TimerView timer)
        {
            _model = model;
            _view = view;
            SetView(view);
            _timerView = timer;
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
        }

        public void SetRoadInCurrentlyActivePool(bool isInCurrent)
        {
            _model.SetRoadInCurrentlyActivePool(isInCurrent);
        }

        public void UpdateRoadPosition(Vector3 position)
        {
            _model.SetPosition(position);
            Vector3 spawnerPosition = Vector3.zero;
            Vector3 despawnerPosition = Vector3.zero;

            switch (_model.StartingSpawn)
            {
                case RoadStartingSpawn.Left:
                    spawnerPosition = new Vector3(-9, _model.Position.y);
                    despawnerPosition = new Vector3(9, _model.Position.y);

                    break;

                case RoadStartingSpawn.Right:
                    spawnerPosition = new Vector3(9, _model.Position.y);
                    despawnerPosition = new Vector3(-9, _model.Position.y);

                    break;
            }

            _model.SetSpawnerAndDespawnerPosition(spawnerPosition, despawnerPosition);
        }

        public void SetRoadActive(bool isActive)
        {
            _model.SetCurrentlyActive(isActive);
        }

        public void SetIsPlayerOnRoad(bool isPlayerOnRoad)
        {
            _model.SetIsPlayerOnRoad(isPlayerOnRoad);
        }

        public void SetStartingSpawn()
        {
            if (_model.Type == RoadType.Sidewalk) return;

            int randomNumber = Random.Range(0, 10);
            Vector3 spawnerPosition;
            Vector3 despawnerPosition;

            if (randomNumber % 2 == 0)
            {
                _model.SetRoadStartingSpawn(RoadStartingSpawn.Right);

                spawnerPosition = new Vector3(9, _model.Position.y);
                despawnerPosition = new Vector3(-9, _model.Position.y);
            }
            else
            {
                _model.SetRoadStartingSpawn(RoadStartingSpawn.Left);

                spawnerPosition = new Vector3(-9, _model.Position.y);
                despawnerPosition = new Vector3(9, _model.Position.y);
            }
            _model.SetSpawnerAndDespawnerPosition(spawnerPosition, despawnerPosition);
        }

        public void SetSpawnRange()
        {
            if(_model.Type == RoadType.Sidewalk) return;

            _model.SetSpawnRange(Random.Range(VehicleSpawnAndSpeed.MIN_SPAWN_TIME, VehicleSpawnAndSpeed.MAX_SPAWN_TIME));
            
            // Set road velocity
            float velocity = VehicleSpawnAndSpeed.GetVehicleSpeed(_model.SpawnRange);
            _model.SetVehicleVelocity(velocity);

            _model.SetTimer(_model.SpawnRange);

            _timerView.SetModel(_model.Timer);
            _timerView.Init(TickTimer);
            StartTimer();
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
                _vehiclePoolController.SpawnVehicleOnRoad(this, _model.IsRoadInCurrentlyActivePool);

                // Restart time
                _model.Timer.StartCountdown(currentTime);
            }
        }

        private void OnPlayerEnterRandomRoad()
        {
            SetIsPlayerOnRoad(true);
            // Add score and distance
            Publish(new AddScoreMessage(5));
            Publish(new AddDistanceMessage());
        }

        private void OnPlayerEnterLastRoad(float xAxis)
        {
            Vector2 resetPosition = new Vector2(xAxis, _roadPoolController.GetFirstLaneYAxis());
            Publish(new PlayerOnLastRoadMessage(resetPosition));
        }
    }
}