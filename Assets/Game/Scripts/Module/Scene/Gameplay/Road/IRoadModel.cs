using Agate.MVC.Base;
using UnityEngine;

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
        public Vector3 Position { get; }
        public bool IsCurrentlyActive { get; }
        public float VehicleVelocity { get; }
    }
}