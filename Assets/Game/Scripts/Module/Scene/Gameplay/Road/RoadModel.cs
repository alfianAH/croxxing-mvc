using Agate.MVC.Base;
using System.Numerics;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadModel : BaseModel, IRoadModel
    {
        public RoadType Type { get; private set; }
        public RoadStartingSpawn StartingSpawn { get; private set; }
        public Vector3 SpawnPosition { get; private set; }
        public Vector3 DespawnPosition { get; private set; }
        public float VehicleVelocity { get; private set; }

        public void SetRoadType(RoadType type)
        {
            Type = type;
            SetDataAsDirty();
        }

        public void SetRoadStartingSpawn(RoadStartingSpawn startingSpawn)
        {
            StartingSpawn = startingSpawn;
            SetDataAsDirty();
        }

        public void SetVehicleVelocity(float vehicleVelocity)
        {
            VehicleVelocity = vehicleVelocity;
            SetDataAsDirty();
        }

        public void SetSpawnPosition(Vector3 spawnPosition)
        {
            SpawnPosition = spawnPosition;
            SetDataAsDirty();
        }

        public void SetDespawnPosition(Vector3 despawnPosition)
        {
            DespawnPosition = despawnPosition;
            SetDataAsDirty();
        }
    }
}