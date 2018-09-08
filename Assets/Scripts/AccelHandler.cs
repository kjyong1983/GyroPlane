using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccelHandler : ButtonHandler
{
    [HideInInspector] public AirplaneController controller;

    public override void OnPointerDown(PointerEventData eventData)
    {
        controller.isSpeedUp = true;
        Debug.Log("speed up button down");
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        controller.isSpeedUp = false;
        Debug.Log("speed up button up");
    }

}
