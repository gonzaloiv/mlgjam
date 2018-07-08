using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelOnEnableScaleBehaviour : MonoBehaviour {

    #region Fields / Properties

    [Header("ScalePanelController")]
    [SerializeField] float time = 0.3f;
    [SerializeField] Ease ease = Ease.InQuart;

    private Vector3 initialScale;

    #endregion

    #region Public Behaviour

    private void Awake () {
        initialScale = transform.localScale;
    }

    private void OnEnable () {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, time)
            .SetEase(ease);
    }

    private void OnDisable () {
        transform.localScale = initialScale;
    }

    #endregion

}
