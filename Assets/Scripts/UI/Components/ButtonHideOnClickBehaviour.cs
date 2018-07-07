using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHideOnClickBehaviour : MonoBehaviour {

    #region Fields / Properties

    private Button button;

    #endregion

    #region Mono Behaviour

    private void Awake () {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => gameObject.SetActive(false));
    }

    #endregion
	
}
