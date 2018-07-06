using System.Collections;
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

        #endregion

    }

}