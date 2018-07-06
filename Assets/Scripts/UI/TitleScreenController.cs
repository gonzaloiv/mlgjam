using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenController : BaseMonoBehaviour {

    #region Fields / Properties

    public Button playButton;

    #endregion

    #region Events

    public delegate void PlayButtonClickEventHandler ();
    public static event PlayButtonClickEventHandler PlayButtonClickEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        playButton.onClick.AddListener(() => PlayButtonClickEvent.Invoke());
    }

    #endregion

}