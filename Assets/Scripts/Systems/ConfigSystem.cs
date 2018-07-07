using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSystem : Singleton<ConfigSystem> {

    [Header("Settings")]
    public LaunchMode launchMode = LaunchMode.Production;
    public DifficultyMode difficultyMode = DifficultyMode.Easy;
    public string gameOverURL = "http://averyrealweb.wordpress.com";

    [Header("Constants")]
    public int maxBannersOnScreen = 10;
    public float roundSpeedRatio = 0.25f;
    public float bonusPercentajePerSecond = 5f;

}