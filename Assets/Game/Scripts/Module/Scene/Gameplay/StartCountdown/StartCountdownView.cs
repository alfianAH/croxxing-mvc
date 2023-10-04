using Agate.MVC.Base;
using Croxxing.Module.Scene.Gameplay.Timer;
using UnityEngine;
using UnityEngine.UI;

namespace Croxxing.Module.Scene.Gameplay.StartCountdown
{
    public class StartCountdownView : BaseView
    {
        [SerializeField] private GameObject _countdownPanel;
        [SerializeField] private Text _countdownInstruction;
        [SerializeField] private Text _countdownText;
        [SerializeField] private Slider _countdownSlider;

        public TimerView Timer { get; private set; }

        public void Init()
        {
            _countdownInstruction.gameObject.SetActive(false);
            _countdownText.gameObject.SetActive(true);
            _countdownSlider.gameObject.SetActive(true);
        }

        public void OnStopTimer()
        {
            _countdownPanel.gameObject.SetActive(false);
        }

        private void Start()
        {
            Timer = GetComponent<TimerView>();
            _countdownPanel.gameObject.SetActive(true);
            _countdownInstruction.gameObject.SetActive(true);
            _countdownText.gameObject.SetActive(false);
            _countdownSlider.gameObject.SetActive(false);
        }
    }
}