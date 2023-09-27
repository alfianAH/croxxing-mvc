using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Road;
using System.Collections.Generic;

namespace Croxxing.Module.Scene.Gameplay.RoadPool
{
    public class RoadPoolModel : BaseModel
    {
        public bool IsPlaying { get; private set; } = false;
        public float RoadHeight { get; private set; } = 1.2f;
        public int PoolSize { get; private set; } = 7;
        public int MaxSidewalkNumber { get; private set; } = 2;
        public List<RoadController> RoadPool { get; private set; } = new List<RoadController>();
        public List<RoadController> CurrentActiveRoad { get; private set; } = new List<RoadController>();

        public void SetIsPlaying(bool isPlaying)
        {
            IsPlaying = isPlaying;
            SetDataAsDirty();
        }

        public void AddRoadPool(RoadController road)
        {
            RoadPool.Add(road);
            SetDataAsDirty();
        }

        public void AddCurrentActiveRoad(RoadController road)
        {
            CurrentActiveRoad.Add(road);
            SetDataAsDirty();
        }

        public void ResetCurrentActiveRoad()
        {
            CurrentActiveRoad.Clear();
            SetDataAsDirty();
        }
    }
}