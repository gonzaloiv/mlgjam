using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Play {

    #region Fields / Properties

    public bool IsGameOver { get { return banners >= ConfigSystem.Instance.maxBannersOnScreen; } }

    public int banners;
    public int score;

    #endregion

}