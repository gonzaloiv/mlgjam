using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerController : BaseMonoBehaviour {

    #region Fields / Properties

    public BannerData bannerData;
    [SerializeField] private Button adButtons;
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
        InitButtons();
    }

    public override void Show () {
        base.Show();
        clicksToHide = closeButtons.Count;
    }

    public void OnCloseButtonClick () {
        CloseEvent.Invoke(bannerData);
        clicksToHide--;
        if (clicksToHide <= 0)
            Hide();
    }

    #endregion

    #region Private Behaviour

    private void InitButtons () {
        adButtons.onClick.AddListener(() => OpenEvent(bannerData));
        closeButtons.ForEach(button => button.onClick.AddListener(OnCloseButtonClick));
    }

    #endregion

}