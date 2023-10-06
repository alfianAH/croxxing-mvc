using System.Collections.Generic;
using UnityEngine;

namespace Croxxing.Utility
{
    public static class VehicleSpawnAndSpeed
    {
        public const int MIN_SPAWN_TIME = 1;
        public const int MAX_SPAWN_TIME = 2;
        private static readonly Dictionary<int, int> _spawnRangeSpeed = new Dictionary<int, int>()
        {
            { 1, Random.Range(4, 8) },
            { 2, Random.Range(2, 6) },
        };

        public static int GetVehicleSpeed(int spawnRange)
        {
            return _spawnRangeSpeed[spawnRange];
        }
    }
}