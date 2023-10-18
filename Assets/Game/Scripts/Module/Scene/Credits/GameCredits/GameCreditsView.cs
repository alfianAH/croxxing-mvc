using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Timer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Credits.GameCredits
{
    public class GameCreditsView : ObjectView<IGameCreditsModel>
    {
        [SerializeField] private Text _titleText;
        [SerializeField] private Text _bodyText;
        [SerializeField] private Button _mainMenuButton;

        public TimerView Timer { get; private set; }

        public void SetCallbacks(UnityAction onClickMainMenu)
        {
            _mainMenuButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.AddListener(onClickMainMenu);
        }

        public void ActivateMainMenuButton()
        {
            _mainMenuButton.gameObject.SetActive(true);
        }

        private void Start()
        {
            Timer = GetComponent<TimerView>();
            _mainMenuButton.gameObject.SetActive(false);
        }

        private void UpdateUI(IGameCreditsModel model)
        {
            _titleText.text = model.Title;
            _bodyText.text = model.Body;
        }

        protected override void InitRenderModel(IGameCreditsModel model)
        {
            UpdateUI(model);
        }

        protected override void UpdateRenderModel(IGameCreditsModel model)
        {
            UpdateUI(model);
        }
    }
}