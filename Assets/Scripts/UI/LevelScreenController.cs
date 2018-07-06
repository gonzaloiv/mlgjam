using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreenController : BaseMonoBehaviour {

    #region Fields / Properties

    [SerializeField] private Text bannersText;
    [SerializeField] private Text scoreText;

    private Play play;

    #endregion

    #region Mono Behaviour

    private void Update () {
        if (play == null)
            return;
        scoreText.text = play.score.ToString();
        bannersText.text = play.banners.ToString();
    }

    #endregion

    #region Public Behaviour

    public void Show (Play play) {
        base.Show();
        this.play = play;
    }


    #endregion

}