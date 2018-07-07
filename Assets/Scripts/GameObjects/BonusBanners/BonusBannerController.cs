using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBannerController : BannerController {

    #region Public Behaviour

    public override void Show () {
        base.Show();
        StartCoroutine(HideRoutine());
    }

    #endregion

    #region Private Behaviour

    private IEnumerator HideRoutine () {
        yield return new WaitForSeconds(bannerData.activeTime);
        Hide();
    }

    #endregion

}