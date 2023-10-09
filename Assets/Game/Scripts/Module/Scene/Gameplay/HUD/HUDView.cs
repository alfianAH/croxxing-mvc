using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.HUD
{
    public class HUDView : ObjectView<IHUDModel>
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _distanceText;

        protected override void InitRenderModel(IHUDModel model)
        {
            _scoreText.text = $"Score: {model.Score}";
            _distanceText.text = $"Distance: {model.Distance}";
        }

        protected override void UpdateRenderModel(IHUDModel model)
        {
            _scoreText.text = $"Score: {model.Score}";
            _distanceText.text = $"Distance: {model.Distance}";
        }
    }
}