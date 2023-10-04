using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Road;
using Croxxing.Module.Scene.Gameplay.RoadPool;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Vehicle
{
    public class VehicleController: ObjectController<VehicleController, VehicleModel, IVehicleModel, VehicleView>
    {
        private RoadPoolController _roadPoolController;

        public void Init(VehicleModel model, VehicleView view)
        {
            _model = model;
            _view = view;
            SetView(view);
        }

        public override void SetView(VehicleView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnUpdate);
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
            Vector3 position = _model.Road.Model.SpawnerPosition;

            switch (_model.Road.Model.StartingSpawn)
            {
                case RoadStartingSpawn.Left:
                    // Move to right
                    position += speed * Time.deltaTime * Vector3.right;
                    break;

                case RoadStartingSpawn.Right:
                    // Move to left
                    position += speed * Time.deltaTime * Vector3.left;
                    break;
            }

            _model.SetPosition(position);
        }
    }
}