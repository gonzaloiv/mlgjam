using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenController : BaseMonoBehaviour {

    #region Fields / Properties

    public Text bestScoreText;
    public Button replayButton;

    #endregion

    #region Events

    public delegate void ReplayButtonClickEventHandler ();
    public static event ReplayButtonClickEventHandler ReplayButtonClickEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        replayButton.onClick.AddListener(() => ReplayButtonClickEvent.Invoke());
    }

    public void Show (int value) {
        base.Show();
        bestScoreText.text = value.ToString();
    }

    #endregion

}