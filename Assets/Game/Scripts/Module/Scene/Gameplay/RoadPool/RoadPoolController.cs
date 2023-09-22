using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Road;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.RoadPool
{
    public class RoadPoolController: ObjectController<RoadPoolController, RoadPoolModel, IRoadPoolModel, RoadPoolView>
    {
        public override void SetView(RoadPoolView view)
        {
            base.SetView(view);
            InitPoolObject();
            SpawnInitRoad();
        }

        public void OnStartPlay()
        {
            _model.SetIsPlaying(true);
        }

        private void InitPoolObject()
        {
            for(int i = 0; i < _model.PoolSize; i++)
            {
                // Add normal road
                AddRoad(RoadType.Normal);

                // Add sidewalk road
                AddRoad(RoadType.Sidewalk);
            }
        }

        private RoadController AddRoad(RoadType roadType)
        {
            RoadModel roadModel = new RoadModel(roadType);
            string prefabName = string.Empty;
            switch (roadType)
            {
                case RoadType.Normal:
                    prefabName = "Normal Road";
                    break;

                case RoadType.Sidewalk:
                    prefabName = "Sidewalk Road";
                    break;
            }

            GameObject roadObjectPrefab = Resources.Load<GameObject>($"Prefabs/Road/{prefabName}");
            GameObject roadObject = Object.Instantiate(roadObjectPrefab, _view.transform);
            RoadView roadView = roadObject.GetComponent<RoadView>();
            RoadController road = new RoadController();

            road.Init(roadModel, roadView);
            _model.AddRoadPool(road);

            return road;
        }

        private RoadController GetOrCreateRoad(RoadType roadType, Vector3 position)
        {
            RoadController road = _model.RoadPool.Find(r => !r.Model.IsCurrentlyActive && r.Model.Type == roadType);

            if (road == null)
            {
                road = AddRoad(roadType);
                _model.AddRoadPool(road);
            }
            
            road.SetPosition(position);
            road.SetCurrentlyActive(true);
            return road;
        }
    
        private void SpawnInitRoad()
        {
            // Add sidewalk on the first
            Vector3 firstLane = new Vector3(0, -4, 0);
            GetOrCreateRoad(RoadType.Sidewalk, firstLane);

            // Add 5 random roads
            SpawnRandomRoad();

            // Add sidewalk on the last
            Vector3 lastLane = new Vector3(0, -4 + (_model.PoolSize - 1)*_model.RoadHeight, 0);
            GetOrCreateRoad(RoadType.Sidewalk, lastLane);
        }

        private void SpawnRandomRoad()
        {
            int sidewalkRoadCount = 0;

            for (int i = 1; i <= _model.PoolSize - 2; i++)
            {
                Vector3 position = new Vector3(0, -4 + i * _model.RoadHeight, 0);

                int randomNumber = Random.Range(0, 2);
                RoadController currentRoad = null;

                switch (randomNumber)
                {
                    case 0:
                        // Normal Road
                        currentRoad = GetOrCreateRoad(RoadType.Normal, position);
                        break;

                    case 1:
                        // Sidewalk road
                        if (sidewalkRoadCount == _model.MaxSidewalkNumber)
                        {
                            currentRoad = GetOrCreateRoad(RoadType.Normal, position);
                        }
                        else
                        {
                            currentRoad = GetOrCreateRoad(RoadType.Sidewalk, position);
                            sidewalkRoadCount++;
                        }
                        break;
                }

                if (currentRoad != null)
                {
                    _model.AddCurrentActiveRoad(currentRoad);
                }
            }
        }
    }
}