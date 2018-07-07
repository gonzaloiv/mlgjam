using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveController : BaseMonoBehaviour {

    #region Fields / Properties

    public float RoundSpawningTime { get { return waveData.spawningTime / 1 + ConfigSystem.Instance.roundSpeedRatio * level.roundIndex; } }

    public int ActiveBannersAmount { get { return banners.Where(banner => banner.isActiveAndEnabled).Count(); } }
    public List<BannerController> InactiveBanners { get { return banners.Where(banner => !banner.isActiveAndEnabled).ToList(); } }

    public WaveData waveData;
    public List<BannerController> banners;

    private float spawnTime = 0;
    private Level level;

    #endregion

    #region Fields / Properties

    public override void Init () {
        banners.ForEach(banner => banner.Init());
    }

    public void Show (Level level) {
        this.level = level;
        StartCoroutine(BannersRoutine());
    }

    public void ShowBanner () {
        if (InactiveBanners.Count > 0)
            InactiveBanners[Random.Range(0, InactiveBanners.Count)].Show();
        spawnTime = Time.time;
    }

    public override void Hide () {
        StopAllCoroutines();
    }

    public void HideBanners () {
        banners.ForEach(banner => banner.Hide());
        StopAllCoroutines();
    }

    #endregion

    #region Private Behaviour

    private IEnumerator BannersRoutine () {
        spawnTime = 0;
        while (gameObject.activeInHierarchy) {
            if (spawnTime + RoundSpawningTime <= Time.time) {
                if (InactiveBanners.Count > 0)
                    InactiveBanners[Random.Range(0, InactiveBanners.Count)].Show();
                spawnTime = Time.time;
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    #endregion

}