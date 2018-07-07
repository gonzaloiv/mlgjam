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
    private Vector2 initialPosition;

    #endregion

    #region Public Behaviour

    private void Awake () {
        initialPosition = transform.localPosition;
    }

    private void OnEnable () {
        switch (direction) {
            case Direction.Left:
                transform.localPosition = new Vector3(transform.localPosition.x - distance, transform.localPosition.y, transform.localPosition.z);
                transform.DOLocalMoveX(initialPosition.x, time).SetEase(ease);
                break;
            case Direction.Right:
                transform.localPosition = new Vector3(transform.localPosition.x + distance, transform.localPosition.y, transform.localPosition.z);
                transform.DOLocalMoveX(initialPosition.x, time).SetEase(ease);
                break;
            case Direction.Up:
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + distance, transform.localPosition.z);
                transform.DOLocalMoveY(initialPosition.y, time).SetEase(ease);
                break;
            case Direction.Down:
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - distance, transform.localPosition.z);
                transform.DOLocalMoveY(initialPosition.y, time).SetEase(ease);
                break;
        }
    }

    private void OnDisable () {
        DOTween.PauseAll();
        switch (direction) {
            case Direction.Left:
                transform.localPosition = new Vector3(transform.localPosition.x - distance, transform.localPosition.y, transform.localPosition.z);
                break;
            case Direction.Right:
                transform.localPosition = new Vector3(transform.localPosition.x + distance, transform.localPosition.y, transform.localPosition.z);
                break;
            case Direction.Up:
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + distance, transform.localPosition.z);
                break;
            case Direction.Down:
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - distance, transform.localPosition.z);
                break;
        }
    }

    #endregion

}
