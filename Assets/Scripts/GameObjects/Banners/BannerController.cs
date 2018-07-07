using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class BannerController : BaseMonoBehaviour {

    #region Fields / Properties

    [Header("BannerController")]
    public BannerData bannerData;
    public AnimationData closingAnimationData;
    [SerializeField] private List<Button> adButtons;
    [SerializeField] private List<Button> closeButtons;
    private int clicksToHide;

    #endregion

    #region Events

    public delegate void OpenEventHandler (BannerData bannerData);
    public static event OpenEventHandler OpenEvent = delegate { };

    public delegate void CloseEventHandler (BannerData bannerData);
    public static event CloseEventHandler CloseEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        if (adButtons != null)
            adButtons.ForEach(button => button.onClick.AddListener(() => OnOpenButtonClick()));
        InitCloseButtons();
    }

    public override void Show () {
        base.Show();
        AudioSystem.Instance.PlayRandomAudioClip(AudioLayer.Error);
        transform.localScale = Vector3.one;
        clicksToHide = closeButtons.Count;
    }


    public virtual void OnCloseButtonClick () {
        clicksToHide--;
        if (closingAnimationData.type != AnimationType.None) {
            ClosingAnimationRoutine(() => {
                base.Hide();
                CloseEvent.Invoke(bannerData);
            });
        } else {
            if (clicksToHide <= 0)
                base.Hide();
            CloseEvent.Invoke(bannerData);
        }
    }

    public virtual void OnOpenButtonClick () {
        OpenEvent.Invoke(bannerData);
    }

    #endregion

    #region Private Behaviour

    private void InitCloseButtons () {
        if (closeButtons != null)
            closeButtons.ForEach(button => button.onClick.AddListener(OnCloseButtonClick));
    }

    private void ClosingAnimationRoutine (Action onComplete) {
        switch (closingAnimationData.type) {
            case AnimationType.Scale:
                transform.DOScale(Vector3.zero, closingAnimationData.time)
                    .SetEase(closingAnimationData.ease)
                    .OnComplete(() => onComplete());
                break;
        }
    }

    #endregion

}