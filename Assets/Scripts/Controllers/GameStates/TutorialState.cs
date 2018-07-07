using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates {

    public class TutorialState : BaseState {

        #region Public Behaviour

        public override void Enter () {
            base.Enter();
            levelScreenController.Show(play);
            tutorialController.Show();
        }

        public override void Exit () {
            base.Exit();
            levelScreenController.Hide();
            tutorialController.Hide();
        }

        public override void Play () {
            if (play.IsGameOver)
                gameController.ToGameOverState();
        }

        public void OnCloseEvent (BannerData bannerData) {
            if (!tutorialController.HasFinished) {
                tutorialController.Show();
            } else {
                gameController.ToLevelState();
            }
        }

        public void OnOpenEvent (BannerData bannerData) {
            gameController.ToTitleState();
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