using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Road;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Vehicle
{
    public class VehicleModel: BaseModel, IVehicleModel
    {
        public VehicleType Type { get; private set; }
        public RoadController Road { get; private set; }
        public Vector3 Position { get ; private set; }
        public bool IsCurrentlyActive { get; private set; } = false;

        public VehicleModel() { }

        public VehicleModel(VehicleType type)
        {
            Type = type;
            SetDataAsDirty();
        }

        public void SetRoad(RoadController road)
        {
            Road = road;
            SetDataAsDirty();
        }

        public void SetCurrentlyActive(bool isCurrentlyActive)
        {
            IsCurrentlyActive = isCurrentlyActive;
            SetDataAsDirty();
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
            SetDataAsDirty();
        }
    }
}