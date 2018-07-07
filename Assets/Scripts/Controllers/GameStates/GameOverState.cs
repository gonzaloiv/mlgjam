using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates {

    public class GameOverState : BaseState {

        #region Public Behaviour

        public override void Enter () {
            base.Enter();
            ApplyBestScoreSystem();
            titleScreenController.Hide();
            gameOverScreenController.Show(play.score);
        }

        public override void Exit () {
            base.Exit();
            gameOverScreenController.Hide();
        }

        public void OnReplayButtonClickEvent () {
            gameController.ToTitleState();   
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            base.AddListeners();
            GameOverScreenController.ReplayButtonClickEvent += OnReplayButtonClickEvent;
        }

        protected override void RemoveListeners () {
            base.RemoveListeners();
            GameOverScreenController.ReplayButtonClickEvent -= OnReplayButtonClickEvent;
        }

        #endregion

        #region Private Behaviour

        private void ApplyBestScoreSystem () {
            if (ScoreService.IsBestScore(play.score))
                ScoreService.SetScore(play.score);
        }

        #endregion

    }

}