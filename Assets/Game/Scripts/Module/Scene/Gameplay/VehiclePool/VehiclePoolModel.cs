using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Vehicle;
using System.Collections.Generic;

namespace Croxxing.Module.Scene.Gameplay.VehiclePool
{
    public class VehiclePoolModel: BaseModel
    {
        public List<VehicleController> VehiclePool { get; private set; } = new List<VehicleController>();
        public List<VehicleController> CurrentActiveVehicle { get; private set; } = new List<VehicleController>();
        public List<VehicleController> NextLevelVehicle { get; private set; } = new List<VehicleController>();
        public int PoolSize { get; private set; } = 5;

        public void AddVehiclePool(VehicleController vehicle)
        {
            VehiclePool.Add(vehicle);
            SetDataAsDirty();
        }

        public void AddCurrentActiveVehiclePool(VehicleController vehicle)
        {
            CurrentActiveVehicle.Add(vehicle);
            SetDataAsDirty();
        }

        public void AddNextLevelVehiclePool(VehicleController vehicle)
        {
            NextLevelVehicle.Add(vehicle);
            SetDataAsDirty();
        }

        public void RemoveCurrentActiveVehiclePool(VehicleController vehicle)
        {
            CurrentActiveVehicle.Remove(vehicle);
            SetDataAsDirty();
        }

        public void RemoveNextLevelVehiclePool(VehicleController vehicle)
        {
            NextLevelVehicle.Remove(vehicle);
            SetDataAsDirty();
        }

        public void ResetCurrentActiveVehiclePool()
        {
            CurrentActiveVehicle.Clear();
            SetDataAsDirty();
        }

        public void ResetNextLevelVehiclePool()
        {
            NextLevelVehicle.Clear();
            SetDataAsDirty();
        }
    }
}