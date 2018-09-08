using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalibrateHandler : ButtonHandler {

    [HideInInspector] public AirplaneController controller;

    public override void OnPointerDown(PointerEventData eventData)
    {
        controller.CalibrateGyro();
        Debug.Log("Gyro Calibrated?");
    }

    public override void OnPointerUp(PointerEventData eventData)
    { }

}
