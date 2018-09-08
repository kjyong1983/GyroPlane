﻿//Attach this script to a GameObject in your Scene.
using UnityEngine;
using UnityEngine.UI;

public class InputGyroExample : MonoBehaviour
{
    Gyroscope m_Gyro;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    //This is a legacy function, check out the UI section for other ways to create your UI
    void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        GUI.Label(new Rect(300, 100, 400, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(300, 150, 400, 40), "Gyro attitude" + m_Gyro.attitude);
        GUI.Label(new Rect(300, 200, 400, 40), "Gyro enabled : " + m_Gyro.enabled);
        GUI.Label(new Rect(300, 250, 400, 40), "Gyro rotationRateUnbiased : " + m_Gyro.rotationRateUnbiased);
        GUI.Label(new Rect(300, 300, 400, 40), "Gyro attitude euler : " + m_Gyro.attitude.ToEulerAngles());
        GUI.Label(new Rect(300, 350, 400, 40), "Gyro userAcceleration : " + m_Gyro.userAcceleration);

    }
}