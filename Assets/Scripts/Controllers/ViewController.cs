using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : BaseMonoBehaviour {

    #region Fields / Properties

    public TitleScreenController titleScreenController;
    public LevelScreenController levelScreenController;
    public GameOverScreenController gameOverScreenController;

    #endregion

    #region Public Behaviour

    public override void Init () {
        titleScreenController.Init();
        levelScreenController.Init();
        gameOverScreenController.Init();
    }

    #endregion

}
