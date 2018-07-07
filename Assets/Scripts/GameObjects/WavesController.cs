using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : BaseMonoBehaviour {

    #region Fields / Proeprties

    public int TotalWaveControllersAmount { get { return waveControllers.Count; } }
    public bool IsLastWave { get { return currentWaveControllerIndex >= waveControllers.Count; } }
    public WaveController CurrentWaveController { get { return waveControllers[level.waveIndex]; } }
    public int CurrentActiveBannersAmount { 
        get { 
            int amount = 0;
            waveControllers.ForEach(waveController => {
                amount += waveController.ActiveBannersAmount;
            });
            return amount;
        } 
    }

    public List<WaveController> waveControllers;
    public int currentWaveControllerIndex;

    private Level level;

    #endregion

    #region Public Behaviour

    public delegate void WaveEndEventHandler (bool isNewRound);
    public static event WaveEndEventHandler WaveEndEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        waveControllers.ForEach(waveController => waveController.Init());
    }

    public void Show (Level level) {
        base.Show();
        this.level = level;
        StartCoroutine(WaveRoutine());
    }

    public override void Hide () {
        waveControllers.ForEach(waveController => waveController.HideBanners());
        StopAllCoroutines();
    }

    #endregion

    #region Private Behaviour

    private void IncreaseCurrentWaveControllerIndex () {
        level.waveIndex++;
        if (level.waveIndex >= waveControllers.Count)
            level.waveIndex = 0;
        WaveEndEvent.Invoke(level.waveIndex == 0);
    }

    private IEnumerator WaveRoutine () {
        CurrentWaveController.Show(level);
        float initialTime = Time.time;
        while (initialTime + CurrentWaveController.waveData.waveTime >= Time.time)
            yield return new WaitForSeconds(0.1f);
        CurrentWaveController.Hide();
        IncreaseCurrentWaveControllerIndex();
        StartCoroutine(WaveRoutine());
    }

    #endregion
	
}