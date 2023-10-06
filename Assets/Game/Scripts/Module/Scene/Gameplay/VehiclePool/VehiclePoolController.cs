using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Road;
using Croxxing.Module.Scene.Gameplay.Vehicle;
using Croxxing.Utility;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.VehiclePool
{
    public class VehiclePoolController: ObjectController<VehiclePoolController, VehiclePoolModel, VehiclePoolView>
    {
        public override void SetView(VehiclePoolView view)
        {
            base.SetView(view);
            InitPoolObject();
        }

        public void SpawnVehicleOnRoad(RoadController road, bool isCurrent)
        {
            int randomNumber = CustomRandomizer.GetRandomValue(
                new RandomSelection(0, 0, 0.50f),
                new RandomSelection(1, 1, 0.25f),
                new RandomSelection(2, 2, 0.20f),
                new RandomSelection(3, 3, 0.05f)
            );
            VehicleController vehicle;

            switch (randomNumber)
            {
                case 0:
                    vehicle = GetOrCreateVehicle(VehicleType.Long);
                    break;

                case 1:
                    vehicle = GetOrCreateVehicle(VehicleType.Medium);
                    break;

                case 2:
                    vehicle = GetOrCreateVehicle(VehicleType.Short);
                    break;

                case 3:
                    vehicle = GetOrCreateVehicle(VehicleType.Coin);
                    break;

                default:
                    return;
            }

            vehicle.SetVehicleActive(true);
            vehicle.SetVehicleProperties(road);

            if(isCurrent)
                _model.AddCurrentActiveVehiclePool(vehicle);
            else
                _model.AddNextLevelVehiclePool(vehicle);
        }

        public void DespawnVehicle(VehicleController vehicle, bool isCurrent)
        {
            vehicle.SetVehicleActive(false);

            if (isCurrent)
                _model.RemoveCurrentActiveVehiclePool(vehicle);
            else
                _model.RemoveNextLevelVehiclePool(vehicle);
        }

        public void PlayerOnLastRoad()
        {
            DespawnCurrentVehicle();
            AddNextToCurrent();
        }

        private void InitPoolObject()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                // Add short vehicle
                AddVehicle(VehicleType.Short);

                // Add medium vehicle
                AddVehicle(VehicleType.Medium);

                // Add long vehicle
                AddVehicle(VehicleType.Long);

                // Add coin
                AddVehicle(VehicleType.Coin);
            }
        }

        private VehicleController AddVehicle(VehicleType vehicleType)
        {
            VehicleModel vehicleModel = new VehicleModel(vehicleType);
            string prefabName = string.Empty;
            switch (vehicleType)
            {
                case VehicleType.Long:
                    prefabName = "Long Vehicle";
                    break;

                case VehicleType.Medium:
                    prefabName = "Medium Vehicle";
                    break;

                case VehicleType.Short:
                    prefabName = "Short Vehicle";
                    break;

                case VehicleType.Coin:
                    prefabName = "Coin";
                    break;
            }

            GameObject vehicleObjectPrefab = Resources.Load<GameObject>($"Prefabs/Vehicle/{prefabName}");
            GameObject vehicleObject = Object.Instantiate(vehicleObjectPrefab, _view.transform);
            VehicleView vehicleView = vehicleObject.GetComponent<VehicleView>();
            VehicleController vehicle = new VehicleController();
            InjectDependencies(vehicle);

            vehicle.Init(vehicleModel, vehicleView);
            _model.AddVehiclePool(vehicle);

            return vehicle;
        }

        private VehicleController GetOrCreateVehicle(VehicleType vehicleType)
        {
            VehicleController vehicle = _model.VehiclePool.Find(v => !v.Model.IsCurrentlyActive && v.Model.Type == vehicleType);

            if (vehicle == null)
            {
                vehicle = AddVehicle(vehicleType);
                _model.AddVehiclePool(vehicle);
            }
            
            return vehicle;
        }
        
        private void DespawnCurrentVehicle()
        {
            foreach (VehicleController vehicle in _model.CurrentActiveVehicle)
            {
                vehicle.SetVehicleActive(false);
            }
            _model.ResetCurrentActiveVehiclePool();
        }

        private void AddNextToCurrent()
        {
            foreach (VehicleController vehicle in _model.NextLevelVehicle)
            {
                // Add vehicle to current
                _model.AddCurrentActiveVehiclePool(vehicle);
            }
            _model.ResetNextLevelVehiclePool();
        }
    }
}