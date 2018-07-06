using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates {

    public class BaseState : State {

        #region Fields / Properties

        public Level level { get { return game.level; } }
        public Play play { get { return game.level.play; } }

        public GameController gameController;

        public TitleScreenController titleScreenController;
        public LevelScreenController levelScreenController;
        public GameOverScreenController gameOverScreenController;

        public Game game;

        #endregion

        #region Mono Behaviour

        private void Awake () {
            this.gameController = GetComponent<GameController>();
            this.titleScreenController = gameController.viewController.titleScreenController;
            this.levelScreenController = gameController.viewController.levelScreenController;
            this.gameOverScreenController = gameController.viewController.gameOverScreenController;
            this.game = gameController.game;
        }

        #endregion

        #region Public Behaviour

        public override void Enter () {
            base.Enter();
            #if UNITY_EDITOR
            Debug.Log(this + ".Enter()");
            #endif
        }

        public override void Exit () {
            base.Exit();
            #if UNITY_EDITOR
            Debug.Log(this + ".Exit()");
            #endif
        }

        #endregion

    }

}