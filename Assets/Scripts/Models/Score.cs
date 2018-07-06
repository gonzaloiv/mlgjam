using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score {

    #region Fields / Properties

    public int value;
    public DateTime timestamp;

    #endregion

    #region Public Behavoiur

    public Score (int value, DateTime timestamp) {
        this.value = value;
        this.timestamp = timestamp;
    }

    #endregion

}