using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates {

    public class TitleState : BaseState {

        #region Public Behaviour

        public override void Enter () {
            base.Enter();
            titleScreenController.Show(ScoreService.GetBestScore());
        }

        public override void Exit () {
            base.Exit();
            titleScreenController.HideBestScoreText();
        }

        public void OnPlayButtonClickEvent () {
            gameController.ToLevelStartState();   
        }

        #endregion

        #region Public Behaviour

        protected override void AddListeners () {
            base.AddListeners();
            TitleScreenController.PlayButtonClickEvent += OnPlayButtonClickEvent;
        }

        protected override void RemoveListeners () {
            base.RemoveListeners();
            TitleScreenController.PlayButtonClickEvent -= OnPlayButtonClickEvent;
        }

        #endregion

    }

}