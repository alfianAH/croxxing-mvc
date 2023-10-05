using Agate.MVC.Base;
using System;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Vehicle
{
    public class VehicleView : ObjectView<IVehicleModel>
    {
        private Action _onUpdate;

        public void SetCallbacks(Action OnUpdate)
        {
            _onUpdate = OnUpdate;
        }

        private void FixedUpdate()
        {
            _onUpdate?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(_model.Type == VehicleType.Coin)
                {
                    Debug.Log("+10");
                }
                else
                {
                    Debug.Log("Game over");
                }
            }
        }

        private void UpdateVehicle(IVehicleModel model)
        {
            gameObject.SetActive(model.IsCurrentlyActive);
            transform.position = model.Position;
        }

        protected override void InitRenderModel(IVehicleModel model)
        {
            UpdateVehicle(model);
        }

        protected override void UpdateRenderModel(IVehicleModel model)
        {
            UpdateVehicle(model);
        }
    }
}