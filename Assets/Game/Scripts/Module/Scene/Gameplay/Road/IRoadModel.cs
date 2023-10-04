using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public enum RoadLane
    {
        First, Middle, Last
    }

    public enum RoadType
    {
        Normal, Sidewalk
    }

    public enum RoadStartingSpawn
    {
        Left, Right
    }

    public interface IRoadModel: IBaseModel
    {
        public RoadType Type { get; }
        public RoadStartingSpawn StartingSpawn { get; }
        public RoadLane Lane { get; }
        public Vector3 Position { get; }
        public Vector3 SpawnerPosition { get; }
        public Vector3 DespawnerPosition { get; }
        public bool IsPlayerOnRoad { get; }
        public bool IsCurrentlyActive { get; }
        public float SpawnRange { get; }
        public float VehicleVelocity { get; }
    }
}