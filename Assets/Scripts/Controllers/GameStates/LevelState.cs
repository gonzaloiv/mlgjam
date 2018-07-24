using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates {

    public class LevelState : BaseState {

        #region Public Behaviour

        public override void Enter () {
            base.Enter();
            
            wavesController.Show(level);
            levelScreenController.Show(play);
            bonusBannersController.Show();
            levelScreenController.levelRoundPanelController.Show(level.roundIndex);
        }

        public override void Exit () {
            base.Exit();
            wavesController.Hide();
            levelScreenController.Hide();
            bonusBannersController.Hide();
        }

        public override void Play () {
            play.banners = wavesController.CurrentActiveBannersAmount;
            if (play.IsGameOver)
                gameController.ToGameOverState();
        }

        public void OnCloseEvent (BannerData bannerData) {
            play.score += bannerData.score;
            ApplyLastBannerSystem();
            AudioSystem.Instance.PlayRandomAudioClip(AudioLayer.Success);
        }

        public void OnOpenEvent (BannerData bannerData) {
            gameController.ToGameOverState();
            Application.OpenURL(ConfigSystem.Instance.gameOverURL);
        }

        public void OnWaveEndEvent (bool isNewRound) {
            if (isNewRound) {
                level.roundIndex++;
                levelScreenController.levelRoundPanelController.Show(level.roundIndex);
            }
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            base.AddListeners();
            BannerController.OpenEvent += OnOpenEvent;
            BannerController.CloseEvent += OnCloseEvent;
            WavesController.WaveEndEvent += OnWaveEndEvent;
        }

        protected override void RemoveListeners () {
            base.RemoveListeners();
            BannerController.OpenEvent -= OnOpenEvent;
            BannerController.CloseEvent -= OnCloseEvent;
            WavesController.WaveEndEvent -= OnWaveEndEvent;
        }

        #endregion

        #region Private Behaviour

        private void ApplyLastBannerSystem () {
            if (wavesController.CurrentActiveBannersAmount == 0)
                wavesController.CurrentWaveController.ShowBanner();
        }

        #endregion

    }

}