﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates {

    public class LevelState : BaseState {

        #region Public Behaviour

        public override void Enter () {
            base.Enter();
            levelScreenController.Show(play);
        }

        public override void Exit () {
            base.Exit();
            levelScreenController.Hide();
        }

        public override void Play () {
            if (play.IsGameOver)
                gameController.ToGameOverState();
        }

        public void OnCloseEvent (BannerData bannerData) {
            play.score += bannerData.score;
        }

        public void OnOpenEvent (BannerData bannerData) {
            gameController.ToGameOverState();
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            base.AddListeners();
            BannerController.OpenEvent += OnOpenEvent;
            BannerController.CloseEvent += OnCloseEvent;
        }

        protected override void RemoveListeners () {
            base.RemoveListeners();
            BannerController.OpenEvent -= OnOpenEvent;
            BannerController.CloseEvent -= OnCloseEvent;
        }

        #endregion

    }

}