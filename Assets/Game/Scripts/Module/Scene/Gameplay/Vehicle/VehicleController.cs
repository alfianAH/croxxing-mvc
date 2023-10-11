using Agate.MVC.Base;
using Croxxing.Module.Message;
using Croxxing.Module.Scene.Gameplay.Audios.SoundEffect;
using Croxxing.Module.Scene.Gameplay.Road;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using Croxxing.Module.Scene.Gameplay.VehiclePool;
using Croxxing.Utility;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Vehicle
{
    public class VehicleController: ObjectController<VehicleController, VehicleModel, IVehicleModel, VehicleView>
    {
        private VehiclePoolController _vehiclePoolController;
        private RoadPoolController _roadPoolController;
        private SoundEffectController _soundEffectController;

        public void Init(VehicleModel model, VehicleView view)
        {
            _model = model;
            _view = view;
            SetView(view);
        }

        public override void SetView(VehicleView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnUpdate, OnCollision);
        }

        public void SetVehicleProperties(RoadController road)
        {
            _model.SetPosition(road.Model.SpawnerPosition);
            _model.SetRoad(road);
        }

        public void SetVehicleActive(bool isActive)
        {
            _model.SetCurrentlyActive(isActive);
        }

        private void OnUpdate()
        {
            if (!_roadPoolController.Model.IsPlaying) return;

            float speed = _model.Road.Model.VehicleVelocity;
            Vector3 position = Vector3.zero;

            switch (_model.Road.Model.StartingSpawn)
            {
                case RoadStartingSpawn.Left:
                    // Move to right
                    position = _model.Position + speed * Time.deltaTime * Vector3.right;

                    if (_model.Position.x > _model.Road.Model.DespawnerPosition.x)
                        _vehiclePoolController.DespawnVehicle(this, _model.Road.Model.IsRoadInCurrentlyActivePool);

                    break;

                case RoadStartingSpawn.Right:
                    // Move to left
                    position = _model.Position + speed * Time.deltaTime * Vector3.left;

                    if (_model.Position.x < _model.Road.Model.DespawnerPosition.x)
                        _vehiclePoolController.DespawnVehicle(this, _model.Road.Model.IsRoadInCurrentlyActivePool);

                    break;
            }

            position = new Vector3(position.x, _model.Road.Model.Position.y);
            _model.SetPosition(position);
        }
        
        private void OnCollision()
        {
            if (_model.Type == VehicleType.Coin)
            {
                Publish(new AddScoreMessage(10));
                // Despawn vehicle
                _vehiclePoolController.DespawnVehicle(this, _model.Road.Model.IsRoadInCurrentlyActivePool);
                _soundEffectController.Play(AudioNames.SFX_COIN);
            }
            else
            {
                Publish(new GameOverMessage());
            }
        }
    }
}