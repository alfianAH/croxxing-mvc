using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadModel : BaseModel, IRoadModel
    {
        public RoadType Type { get; private set; }
        public RoadStartingSpawn StartingSpawn { get; private set; }
        public RoadLane Lane { get; private set; }
        public Vector3 Position { get; private set; }
        public bool IsPlayerOnRoad { get; private set; }
        public bool IsRandom { get; private set; } = true;
        public bool IsCurrentlyActive { get; private set; } = false;
        public float VehicleVelocity { get; private set; }

        public RoadModel () { }

        public RoadModel(RoadType type)
        {
            Type = type;
            SetDataAsDirty();
        }

        public void SetRoadStartingSpawn(RoadStartingSpawn startingSpawn)
        {
            StartingSpawn = startingSpawn;
            SetDataAsDirty();
        }

        public void SetRoadLane(RoadLane lane)
        {
            Lane = lane;
            SetDataAsDirty();
        }

        public void SetCurrentlyActive(bool isActive)
        {
            IsCurrentlyActive = isActive;
            SetDataAsDirty();
        }

        public void SetIsPlayerOnRoad(bool isPlayerOnRoad)
        {
            IsPlayerOnRoad = isPlayerOnRoad;
            SetDataAsDirty();
        }

        public void SetVehicleVelocity(float vehicleVelocity)
        {
            VehicleVelocity = vehicleVelocity;
            SetDataAsDirty();
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
            SetDataAsDirty();
        }
    }
}