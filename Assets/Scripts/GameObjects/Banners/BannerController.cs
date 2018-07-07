﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerController : BaseMonoBehaviour {

    #region Fields / Properties

    [Header("BannerController")]
    public BannerData bannerData;
    [SerializeField] private Button adButton;
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
        adButton.onClick.AddListener(() => OnOpenButtonClick());
        InitCloseButtons();
    }

    public override void Show () {
        base.Show();
        clicksToHide = closeButtons.Count;
    }

    public virtual void OnCloseButtonClick () {
        CloseEvent.Invoke(bannerData);
        clicksToHide--;
        if (clicksToHide <= 0)
            Hide();
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

    #endregion

}