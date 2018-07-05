using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    #region Fields

    protected static T instance;

    #endregion

    #region  Singleton Pattern

    public static T Instance {
        get {
            if (instance == null)
                instance = (T) FindObjectOfType(typeof(T));
            return instance;
        }
    }

    #endregion

    #region Public Behaviour

    public static void Delete () {
        Debug.Log("Deleting Singleton of type: " + typeof(T));
        instance = default(T);
    }

    #endregion

}