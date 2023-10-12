using Agate.MVC.Base;
using Croxxing.Utility;
using UnityEngine;

namespace Croxxing.Module.Scene.Gameplay.Audios.BackgroundMusic
{
    public class BackgroundMusicController: ObjectController<BackgroundMusicController, BackgroundMusicView>
    {
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

        private BackgroundMusicConfig GetBackgroundMusic(string audioName)
        {
            BackgroundMusicConfig backgroundMusic = _view.BackgroundMusics.Find(
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