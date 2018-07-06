using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameStates;

public class GameController : StateMachine {

    #region Fields / Properties

    public ViewController viewController;
    public Game game;

    #endregion

    #region Mono Behaviour

    private void Awake () {
        viewController.Init();
        game = new Game();
        ToTitleState();
    }

    #endregion

    #region Public Behaviour

    public void ToTitleState () {
        ChangeState<TitleState>();
    }

    public void ToLevelState () {
        ChangeState<LevelState>();
    }

    public void ToGameOverState () {
        ChangeState<GameOverState>();
    }

    #endregion

}