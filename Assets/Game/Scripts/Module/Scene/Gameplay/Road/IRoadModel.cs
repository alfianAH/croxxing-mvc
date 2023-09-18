using Agate.MVC.Base;
using System.Numerics;

namespace Croxxing.Module.Scene.Gameplay.Road
{
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
        public Vector3 SpawnPosition { get; }
        public Vector3 DespawnPosition { get; }
        public float VehicleVelocity { get; }
    }
}