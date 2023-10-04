using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Vehicle;
using System.Collections.Generic;

namespace Croxxing.Module.Scene.Gameplay.VehiclePool
{
    public class VehiclePoolModel: BaseModel
    {
        public List<VehicleController> VehiclePool { get; private set; } = new List<VehicleController>();
        public int PoolSize { get; private set; } = 5;

        public void AddVehiclePool(VehicleController vehicle)
        {
            VehiclePool.Add(vehicle);
            SetDataAsDirty();
        }
    }
}