using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BonusBannersController : BaseMonoBehaviour {

    #region Fields / Properties

    public bool ShouldSetBonusBannerActive { get { return Random.Range(0, 100) < ConfigSystem.Instance.bonusPercentajePerSecond; } }
    public bool IsActive { get { return bonusBanners.Any(banner => banner.isActiveAndEnabled); } }
    public List<BonusBannerController> bonusBanners;

    #endregion

    #region Public Behaviour

    public override void Init () {
        bonusBanners.ForEach(banner => banner.Init());
    }

    public override void Show () {
        StartCoroutine(BonusBannersRoutine());
    }

    public override void Hide () {
        StopAllCoroutines();
    }

    #endregion

    #region Private Behaviour

    private IEnumerator BonusBannersRoutine () {
        while (gameObject.activeInHierarchy) {
            yield return new WaitForSeconds(1);
            if (ShouldSetBonusBannerActive)
                bonusBanners[Random.Range(0, bonusBanners.Count)].Show();
        }       
    }

    #endregion
	
}