using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableBannerController : BannerController {

    #region Fields / Properties

    public DraggableAreaController draggableAreaController;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        draggableAreaController.Init(OnCloseDrag);
    }

    public void OnCloseDrag () {
        if (closingAnimationData.type != AnimationType.None) {
            ClosingAnimationRoutine(() => {
                base.Hide();
                InvokeCloseEvent();
            });
        } else {
            if (clicksToHide <= 0)
                base.Hide();
            InvokeCloseEvent();
        }
    }

    #endregion
    	
}