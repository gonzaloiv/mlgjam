using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenController : BaseMonoBehaviour {

    #region Fields / Properties

    public Text bestScoreText;
    public Button playButton;

    #endregion

    #region Events

    public delegate void PlayButtonClickEventHandler ();
    public static event PlayButtonClickEventHandler PlayButtonClickEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        playButton.onClick.AddListener(() => PlayButtonClickEvent.Invoke());
    }

    public void Show (Score score = null) {
        base.Show();     
        if (score != null) {
            bestScoreText.gameObject.SetActive(true);
            bestScoreText.text = score.value.ToString();
        } else {
            bestScoreText.gameObject.SetActive(false);
        }
    }

    public void HideBestScoreText() {
        bestScoreText.gameObject.SetActive(false); 
    }

    #endregion

}