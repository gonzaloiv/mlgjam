using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreService {

    #region Fields / Properties

    private const string BEST_SCORE_KEY = "BestScore";

    #endregion

    #region Public Behaviour

    public static Score GetBestScore () {
        return JsonUtility.FromJson<Score>(PlayerPrefs.GetString(BEST_SCORE_KEY));
    }

    public static bool SetScore (int value) {
        Score currentBestScore = GetBestScore();
        if (currentBestScore == null || currentBestScore.value <= value) {
            PlayerPrefs.SetString(BEST_SCORE_KEY, JsonUtility.ToJson(new Score(value, DateTime.Now)));
            return true;
        } else {
            return false;
        }
    }

    #endregion
	
}