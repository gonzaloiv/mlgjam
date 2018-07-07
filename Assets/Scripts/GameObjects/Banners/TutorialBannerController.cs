using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialBannerController : BannerController {

    #region Fields / Properties

    [Header("TutorialBannerController")]
    public AnimationData punchAnimationData;

    #endregion

    #region Public Behaviour

    public override void OnOpenButtonClick () {
        transform.DOPunchScale(Vector3.one * punchAnimationData.strength, punchAnimationData.time)
            .SetEase(Ease.InOutBounce);
    }

    #endregion
	
}