using Agate.MVC.Base;
using Croxxing.Utility;
using System.Collections;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic
{
    public class BackgroundMusicController: ObjectController<BackgroundMusicController, BackgroundMusicModel, BackgroundMusicView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadBackgroundMusic();
        }

        public override void SetView(BackgroundMusicView view)
        {
            base.SetView(view);

            Play(AudioNames.BGM);
        }

        public void Play(string audioName)
        {
            AudioSource audioSource = _view.GetComponent<AudioSource>();
            BackgroundMusicConfig bgm = GetBackgroundMusic(audioName);

            audioSource.clip = bgm.Clip;
            audioSource.loop = bgm.IsLoop;
            audioSource.volume = bgm.Volume;
            audioSource.pitch = bgm.Pitch;
            audioSource.Play();
        }

        private void LoadBackgroundMusic()
        {
            BackgroundMusicScriptableObject bgm = Resources.Load<BackgroundMusicScriptableObject>("Scriptable Objects/Audio/Background Musics");
            _model.SetBackgroundMusic(bgm);
        }

        private BackgroundMusicConfig GetBackgroundMusic(string audioName)
        {
            BackgroundMusicConfig backgroundMusic = _model.BackgroundMusic.BackgroundMusics.Find(
                b => {
                    if (b.Name.ToLower() == audioName.ToLower())
                    {
                        return true;
                    }
                    return false;
                }
            );
            if (backgroundMusic != null) return backgroundMusic;

            Debug.LogError($"Audio clip: {audioName} not available");
            return null;
        }
    }
}