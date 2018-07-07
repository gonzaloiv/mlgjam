using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : BaseMonoBehaviour {

    #region Fields / Properties

    public bool HasFinished { get { return currentBannerIndex >= banners.Count; } }

    public List<BannerController> banners;
    private int currentBannerIndex = 0;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        banners.ForEach(banner => banner.Init());
    }

    public override void Show () {
        base.Show();
        banners[currentBannerIndex].Show();
        currentBannerIndex++;
    }

    public override void Hide () {
        base.Hide();
        currentBannerIndex = 0;
    }

    #endregion

}