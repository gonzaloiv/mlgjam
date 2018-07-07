using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;

public class GameController : StateMachine {

    #region Fields / Properties

    public ViewController viewController;
    public TutorialController tutorialController;
    public WavesController wavesController;
    public BonusBannersController bonusBannersController;
    public Game game;

    #endregion

    #region Mono Behaviour

    private void Awake () {
        viewController.Init();
        tutorialController.Init();
        wavesController.Init();
        bonusBannersController.Init();
        game = new Game();
        ToTitleState();
    }

    #endregion

    #region Public Behaviour

    public void ToTitleState () {
        ChangeState<TitleState>();
    }

    public void ToLevelStartState () {
        game.level.Init();
        game.plays++;
        if (game.plays <= 1) {
            ChangeState<TutorialState>();
        } else {
            ChangeState<LevelState>();
        }
    }

    public void ToLevelState () {
        ChangeState<LevelState>();
    }

    public void ToGameOverState () {
        ChangeState<GameOverState>();
    }

    #endregion

}