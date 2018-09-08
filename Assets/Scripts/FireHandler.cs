using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireHandler : ButtonHandler {

    [HideInInspector] public AirplaneController controller;

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("fire button pressed");
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("fire button up");
    }
}
