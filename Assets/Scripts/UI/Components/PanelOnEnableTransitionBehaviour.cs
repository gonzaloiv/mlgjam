using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelOnEnableTransitionBehaviour : MonoBehaviour {

    #region Fields / Properties

    [Header("MovePanelController")]
    [SerializeField] private float time = 0.3f;
    [SerializeField] private  Ease ease = Ease.InOutQuart;
    [SerializeField] Direction direction;
    [SerializeField] private float distance = 200f;

    private RectTransform rectTransform;
    private Vector2 initialPosition;

    #endregion

    #region Mono Behaviour

    private void OnEnable () {
        if (rectTransform == null)
            return;
        switch (direction) {
            case Direction.Left:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - distance, rectTransform.anchoredPosition.y);
                rectTransform.DOAnchorPosX(initialPosition.x, time).SetEase(ease);
                break;
            case Direction.Right:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + distance, rectTransform.anchoredPosition.y);
                rectTransform.DOAnchorPosX(initialPosition.x, time).SetEase(ease);
                break;
            case Direction.Up:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + distance);
                rectTransform.DOAnchorPosY(initialPosition.y, time).SetEase(ease);
                break;
            case Direction.Down:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - distance);
                rectTransform.DOAnchorPosY(initialPosition.y, time).SetEase(ease);
                break;
        }
    }

    private void OnDisable () {
        if (rectTransform == null)
            return;
        DOTween.PauseAll();
        switch (direction) {
            case Direction.Left:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x - distance, rectTransform.anchoredPosition.y);
                break;
            case Direction.Right:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + distance, rectTransform.anchoredPosition.y);
                break;
            case Direction.Up:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + distance);
                break;
            case Direction.Down:
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - distance);
                break;
        }
    }

    #endregion

    #region Public Behaviour

    public void Init (RectTransform rectTransform, Vector3 initialPosition) {
        this.rectTransform = rectTransform;
        this.initialPosition = initialPosition;
    }

    #endregion

}
