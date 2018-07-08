using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleScreenController : BaseMonoBehaviour {

    #region Fields / Properties

    private const int TITLE_Y_MOVE = 1000;

    public Text bestScoreText;
    public Image titleImage;
    public Button playButton;

    public Vector3 initialTitlePosition;

    #endregion

    #region Events

    public delegate void PlayButtonClickEventHandler ();
    public static event PlayButtonClickEventHandler PlayButtonClickEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        playButton.onClick.AddListener(() => PlayButtonClickEvent.Invoke());
        initialTitlePosition = titleImage.transform.localPosition;
    }

    public void Show (Score score = null) {
        base.Show();     
        ShowTitlePanels();
        if (score != null) {
            bestScoreText.gameObject.SetActive(true);
            bestScoreText.text = score.value.ToString();
        } else {
            bestScoreText.gameObject.SetActive(false);
        }
    }

    public void HideTitlePanels () {
        titleImage.transform.DOLocalMove(initialTitlePosition + new Vector3(0, TITLE_Y_MOVE, 0), 0.3f)
            .SetEase(Ease.InOutBounce);
        playButton.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false); 
    }

    #endregion

    #region Private Behavoiur

    private void ShowTitlePanels () {
        titleImage.transform.localPosition = initialTitlePosition + new Vector3(0, TITLE_Y_MOVE, 0);
        titleImage.transform.DOLocalMove(initialTitlePosition, 0.3f)
            .SetEase(Ease.InOutBounce);
        titleImage.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
    }

    #endregion

}