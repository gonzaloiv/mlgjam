﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Level {

    #region Fields / Properties

    public Play play = new Play();
    public int roundIndex;
    public int waveIndex;

    #endregion

    #region Public Behaviour

    public void Init() {
        roundIndex = 0;
        waveIndex = 0;
        play.Init();
    }

    #endregion

}