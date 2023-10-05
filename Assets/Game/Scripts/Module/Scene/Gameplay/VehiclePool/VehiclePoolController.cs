using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Road;
using Croxxing.Module.Scene.Gameplay.Vehicle;
using System.Linq;
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

        public void SpawnVehicleOnRoad(RoadController road)
        {
            int randomNumber = Random.Range(0, 4);
            VehicleController vehicle = null;

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
            }

            vehicle.SetVehicleActive(true);
            vehicle.SetVehicleProperties(road);
        }

        public void PlayerOnLastRoad()
        {
            foreach(VehicleController vehicle in _model.VehiclePool.Where(v => v.Model.IsCurrentlyActive)){
                vehicle.SetVehicleActive(false);
            }
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
    }
}