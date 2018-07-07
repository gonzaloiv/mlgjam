using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelShakeBehaviour : MonoBehaviour {

    #region Fields / Properties

    public bool doubleShake = false;
    public AnimationData animationData;
    private Sequence sequence;

    #endregion

    #region Public Behaviour

    private void Awake () {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOPunchScale(Vector3.one * animationData.strength, animationData.time));
        if (doubleShake)
            sequence.Append(transform.DOPunchScale(Vector3.one * animationData.strength, animationData.time));
        sequence.PrependInterval(animationData.pauseTime);
        sequence.SetLoops(-1);   
            
    }

    private void OnEnable () {
        sequence.Play();
    }

    private void OnDisable () {
        sequence.Rewind();       
    }

    #endregion

}