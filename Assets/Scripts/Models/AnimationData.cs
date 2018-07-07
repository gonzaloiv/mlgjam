using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[Serializable]
public class AnimationData {
    public AnimationType type;
    public Direction direction;
    public float strength;
    public float time;
    public float pauseTime;
    public Ease ease;
}