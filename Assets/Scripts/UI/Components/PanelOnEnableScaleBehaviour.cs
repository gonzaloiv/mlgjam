using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelOnEnableScaleBehaviour : MonoBehaviour {

    #region Fields / Properties

    [Header("ScalePanelController")]
    [SerializeField] float time = 0.3f;
    [SerializeField] Ease ease = Ease.InQuart;

    private RectTransform rectTransform;
    private Vector3 initialScale;

    #endregion

    #region Public Behaviour

    private void OnEnable () {
        if (rectTransform == null)
            return;
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(initialScale, time)
            .SetEase(ease);
    }

    #endregion

    #region Private Behaviour

    public void Init (RectTransform rectTransform, Vector3 initialScale) {
        this.rectTransform = rectTransform;
        this.initialScale = initialScale;
    }

    #endregion

}
