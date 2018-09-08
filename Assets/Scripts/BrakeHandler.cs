using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeHandler : ButtonHandler
{
    [HideInInspector] public AirplaneController controller;

    public override void OnPointerDown(PointerEventData eventData)
    {
        controller.isSpeedDown = true;
        Debug.Log("speed down button down");
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        controller.isSpeedDown = false;
        Debug.Log("speed down button up");
    }
}
