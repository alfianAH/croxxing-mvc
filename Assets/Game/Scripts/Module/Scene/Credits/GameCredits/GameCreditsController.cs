using Agate.MVC.Base;
using Croxxing.Boot;
using Croxxing.Utility;
using System.Collections;
using UnityEngine;

namespace Croxxing.Module.Scene.Credits.GameCredits
{
    public class GameCreditsController: ObjectController<GameCreditsController, GameCreditsModel, IGameCreditsModel, GameCreditsView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadGameCreditJson();
        }

        public override void SetView(GameCreditsView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickMainMenu);

            LoadGameCredit();
            _model.SetTimer(2);
            _view.Timer.SetModel(_model.Timer);
            _view.Timer.Init(TickTimer);
            StartTimer();
        }

        private void StartTimer()
        {
            _model.Timer.StartCountdown(GameUtils.GetCurrentTime());
        }

        private void TickTimer()
        {
            long currentTime = GameUtils.GetCurrentTime();
            _model.Timer.UpdateCountdown(currentTime);

            if (_model.Timer.IsCompleted)
            {
                // Set title and body
                if (_model.Index + 1 != _model.GameCredits.credits.Count)
                {
                    _model.IncreaseIndex();
                    LoadGameCredit();

                    // Restart time
                    _model.Timer.StartCountdown(currentTime);
                }
                else
                {
                    _view.ActivateMainMenuButton();
                }
            }
        }

        private void LoadGameCreditJson()
        {
            TextAsset gameCreditsFile = Resources.Load<TextAsset>("Data/Credits/credits");
            GameCreditsFull gameCredits = JsonUtility.FromJson<GameCreditsFull>(gameCreditsFile.text);
            _model.SetGameCredits(gameCredits);
        }

        private void LoadGameCredit()
        {
            _model.SetTitle(_model.GameCredits.credits[_model.Index].title);
            string body = string.Empty;
            foreach(string bodyText in _model.GameCredits.credits[_model.Index].body)
            {
                body += $"{bodyText}\n";
            }
            _model.SetBody(body);
        }

        private void OnClickMainMenu()
        {
            SceneLoader.Instance.LoadScene(GameScenes.MAIN_MENU);
        }
    }
}