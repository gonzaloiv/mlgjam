using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DraggableAreaController : BaseMonoBehaviour, IDragHandler, IEndDragHandler {

    #region Fields / Properties

    public Direction closeDirection;
    private Action onCloseDrag;

    #endregion

    #region Mono Behaviour

    public void OnDrag (PointerEventData eventData) { }

    public void OnEndDrag (PointerEventData eventData) {
        Vector3 drag = (eventData.position - eventData.pressPosition).normalized;
        Direction direction;
        if (Mathf.Abs(drag.x) > Mathf.Abs(drag.y)) {
            direction = (drag.x > 0) ? Direction.Right : Direction.Left;
        } else {
            direction = (drag.y > 0) ? Direction.Up : Direction.Down;
        }
        if (closeDirection == direction)
            onCloseDrag();
        Debug.LogWarning("OnEndDrag");
    }

    #endregion

    #region Public Behaviour

    public void Init (Action onCloseDrag) {
        this.onCloseDrag = onCloseDrag;
    }

    #endregion
    	
}