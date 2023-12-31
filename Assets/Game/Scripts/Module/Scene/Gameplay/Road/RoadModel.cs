using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Timer;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadModel : BaseModel, IRoadModel
    {
        public RoadType Type { get; private set; }
        public RoadStartingSpawn StartingSpawn { get; private set; }
        public RoadLane Lane { get; private set; }
        public TimerModel Timer { get; private set; }
        public Vector3 Position { get; private set; }
        public Vector3 SpawnerPosition { get; private set; }
        public Vector3 DespawnerPosition { get; private set; }
        public bool IsPlayerOnRoad { get; private set; }
        public bool IsRoadInCurrentlyActivePool { get; private set; }
        public bool IsCurrentlyActive { get; private set; } = false;
        public int SpawnRange { get; private set; }
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

        public void SetRoadInCurrentlyActivePool(bool isInCurrent)
        {
            IsRoadInCurrentlyActivePool = isInCurrent;
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

        public void SetSpawnerAndDespawnerPosition(Vector3 spawnerPosition, Vector3 despawnerPosition)
        {
            SpawnerPosition = spawnerPosition;
            DespawnerPosition = despawnerPosition;
            SetDataAsDirty();
        }

        public void SetSpawnRange(int spawnRange)
        {
            SpawnRange = spawnRange;
            SetDataAsDirty();
        }

        public void SetTimer(int second)
        {
            Timer = new TimerModel(second);
            SetDataAsDirty();
        }
    }
}