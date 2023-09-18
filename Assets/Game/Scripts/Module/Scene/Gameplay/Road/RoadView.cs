using Agate.MVC.Base;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Road
{
    public class RoadView : ObjectView<IRoadModel>
    {
        [Header("Position")]
        [SerializeField] private Transform _leftPositionTransform;
        [SerializeField] private Transform _rightPositionTransform;

        [Header("Road Type")]
        [SerializeField] private Sprite _normalRoadSprite;
        [SerializeField] private Sprite _sidewalkRoadSprite;
        private SpriteRenderer _spriteRenderer;

        [Header("Spawn and Despawn")]
        [SerializeField] private GameObject _spawner;
        [SerializeField] private GameObject _despawner;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void UpdateRoad(IRoadModel model)
        {
            // Road type sprite
            switch(model.Type)
            {
                case RoadType.Normal:
                    _spriteRenderer.sprite = _normalRoadSprite;
                    break;

                case RoadType.Sidewalk:
                    _spriteRenderer.sprite = _sidewalkRoadSprite;
                    break;
            }

            // Spawner and despawner position
            switch (model.StartingSpawn)
            {
                case RoadStartingSpawn.Left:
                    _spawner.transform.position = _leftPositionTransform.position;
                    _despawner.transform.position = _rightPositionTransform.position;
                    break;
                
                case RoadStartingSpawn.Right:
                    _spawner.transform.position = _rightPositionTransform.position;
                    _despawner.transform.position = _leftPositionTransform.position;
                    break;
            }
        }

        protected override void InitRenderModel(IRoadModel model)
        {
            UpdateRoad(model);
        }

        protected override void UpdateRenderModel(IRoadModel model)
        {
            UpdateRoad(model);
        }
    }
}