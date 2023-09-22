using Agate.MVC.Base;
using System;
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

        private Action _onPlayerEnterRandomRoad;

        public void SetCallbacks(Action onPlayerEnterRandomRoad)
        {
            _onPlayerEnterRandomRoad = onPlayerEnterRandomRoad;
        }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                switch (_model.Lane)
                {
                    case RoadLane.Middle:
                        if (_model.IsCurrentlyActive && !_model.IsPlayerOnRoad)
                        {
                            _onPlayerEnterRandomRoad.Invoke();
                        }
                        break;

                    case RoadLane.Last:
                        Debug.Log("hai");
                        break;

                    case RoadLane.First:
                    default:
                        break;
                }
            }
        }

        private void UpdateRoad(IRoadModel model)
        {
            // Road type sprite
            /*switch(model.Type)
            {
                case RoadType.Normal:
                    _spriteRenderer.sprite = _normalRoadSprite;
                    break;

                case RoadType.Sidewalk:
                    _spriteRenderer.sprite = _sidewalkRoadSprite;
                    break;
            }*/

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

            gameObject.SetActive(_model.IsCurrentlyActive);
            transform.position = _model.Position;
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