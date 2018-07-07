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
        }

        public override void Exit () {
            base.Exit();
            wavesController.Hide();
            levelScreenController.Hide();
        }

        public override void Play () {
            play.banners = wavesController.CurrentActiveBannersAmount;
            if (play.IsGameOver)
                gameController.ToGameOverState();
        }

        public void OnCloseEvent (BannerData bannerData) {
            play.score += bannerData.score;
        }

        public void OnOpenEvent (BannerData bannerData) {
            gameController.ToGameOverState();
        }

        public void OnWaveEndEvent (bool isNewRound) {
            Debug.LogWarning("Round Index: " + level.roundIndex);
            Debug.LogWarning("Wave Index: " + (level.waveIndex + level.roundIndex * wavesController.TotalWaveControllersAmount));
            Debug.LogWarning("Is new round? " + isNewRound);
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

    }

}