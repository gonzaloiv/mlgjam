using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelRoundPanelController : BaseMonoBehaviour {

    #region Fields / Properties

    private const string BASE_ROUND_TEXT = "Round ";

    public float textTime = 1f;

    [SerializeField] private Text roundText;
    [SerializeField] private Text fightText;

    #endregion

    #region Public Behaviour

    public override void Init () {
        HideTexts();
    }

    public void Show (int roundIndex) {
        base.Show();
        roundText.text = BASE_ROUND_TEXT + (roundIndex + 1).ToString();
        StartCoroutine(RoundRoutine());
    }

    #endregion

    #region Private Behaviour

    private IEnumerator RoundRoutine () {
        HideTexts();
        roundText.gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        HideTexts();
        fightText.gameObject.SetActive(true);
        yield return new WaitForSeconds(textTime);
        HideTexts();
    }

    private void HideTexts () {
        roundText.gameObject.SetActive(false);
        fightText.gameObject.SetActive(false);
    }

    #endregion
	
}
