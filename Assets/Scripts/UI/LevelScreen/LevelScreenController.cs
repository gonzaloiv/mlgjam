using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreenController : BaseMonoBehaviour {

    #region Fields / Properties

    public LevelRoundPanelController levelRoundPanelController;
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
        bannersText.gameObject.SetActive(play.banners > 0);
    }

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        levelRoundPanelController.Init();
    }

    public void Show (Play play) {
        base.Show();
        this.play = play;
    }


    #endregion

}