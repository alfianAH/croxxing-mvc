using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Vehicle
{
    public enum VehicleType
    {
        Short, Medium, Long, Coin
    }

    public interface IVehicleModel: IBaseModel
    {
        public VehicleType Type { get; }
        public Vector3 Position { get; }
        public bool IsCurrentlyActive { get; }
    }
}