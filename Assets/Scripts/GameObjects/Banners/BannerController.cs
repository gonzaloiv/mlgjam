using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Linq;

public class BannerController : BaseMonoBehaviour {

    #region Fields / Properties

    public bool HasActiveCloseButtons { get { return closeButtons.Any(button => button.isActiveAndEnabled); } }

    [Header("Data")]
    public BannerData bannerData;
    public AnimationData closingAnimationData;

    [Header("UI")]
    [SerializeField] private List<Button> adButtons;
    [SerializeField] private List<Button> closeButtons;
    protected int clicksToHide;

    protected RectTransform rectTransform;
    protected PanelOnEnableScaleBehaviour panelOnEnableScaleBehaviour;
    protected PanelOnEnableTransitionBehaviour panelOnEnableTransitionBehaviour;
    protected Vector2 initialPosition;
    protected Vector2 initialScale;

    #endregion

    #region Events

    public delegate void OpenEventHandler (BannerData bannerData);
    public static event OpenEventHandler OpenEvent = delegate { };

    public delegate void CloseEventHandler (BannerData bannerData);
    public static event CloseEventHandler CloseEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {

        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;
        initialScale = rectTransform.localScale;

        if (adButtons != null)
            adButtons.ForEach(button => button.onClick.AddListener(() => OnOpenButtonClick()));
        if (closeButtons != null)
            closeButtons.ForEach(button => button.onClick.AddListener(OnCloseButtonClick));

        panelOnEnableScaleBehaviour = GetComponent<PanelOnEnableScaleBehaviour>();
        if (panelOnEnableScaleBehaviour != null)
            panelOnEnableScaleBehaviour.Init(rectTransform, initialScale);
        
        panelOnEnableTransitionBehaviour = GetComponent<PanelOnEnableTransitionBehaviour>();
        if (panelOnEnableTransitionBehaviour != null)
            panelOnEnableTransitionBehaviour.Init(rectTransform, initialPosition);

        base.Init();

    }

    public override void Show () {
        base.Show();
        rectTransform.anchoredPosition = initialPosition;
        rectTransform.localScale = initialScale;
        closeButtons.ForEach(button => button.gameObject.SetActive(true));
        AudioSystem.Instance.PlayRandomAudioClip(AudioLayer.Error);
        clicksToHide = closeButtons.Count;
    }

    public virtual void OnCloseButtonClick () {
        clicksToHide--;
        if (clicksToHide > 0 && HasActiveCloseButtons)
            return;
        if (closingAnimationData.type != AnimationType.None) {
            ClosingAnimationRoutine(() => {
                base.Hide();
                CloseEvent.Invoke(bannerData);
            });
        } else {
            base.Hide();
            CloseEvent.Invoke(bannerData);
        }
    }

    public virtual void OnOpenButtonClick () {
        OpenEvent.Invoke(bannerData);
    }

    public void InvokeCloseEvent () {
        CloseEvent.Invoke(bannerData);
    }

    #endregion

    #region protected Behaviour

    protected void ClosingAnimationRoutine (Action onComplete) {
        switch (closingAnimationData.type) {
            case AnimationType.Scale:
                transform.DOScale(Vector3.zero, closingAnimationData.time)
                    .SetEase(closingAnimationData.ease)
                    .OnComplete(() => onComplete());
                break;
            case AnimationType.Transition:
                transform.DOMove(GetTransitionPosition(), closingAnimationData.time)
                    .SetEase(closingAnimationData.ease)
                    .OnComplete(() => onComplete());
                break;
        }
    }

    protected Vector3 GetTransitionPosition () {
        switch (closingAnimationData.direction) {
            case Direction.Up:
                return new Vector3(0, closingAnimationData.strength, 0); 
            case Direction.Down:
                return new Vector3(0, -closingAnimationData.strength, 0); 
            case Direction.Left:
                return new Vector3(-closingAnimationData.strength, 0, 0); 
            case Direction.Right:
                return new Vector3(closingAnimationData.strength, 0, 0);
        }
        return Vector3.zero;
    }

    #endregion

}