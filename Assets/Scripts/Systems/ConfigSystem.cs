using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSystem : Singleton<ConfigSystem> {

    [Header("Settings")]
    public LaunchMode launchMode = LaunchMode.Production;
    public DifficultyMode difficultyMode = DifficultyMode.Easy;

    [Header("Constants")]
    public int maxBannersOnScreen = 10;
    public float roundSpeedRatio = 0.25f;

}