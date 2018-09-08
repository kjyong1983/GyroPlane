using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroControl : Photon.MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;

    private Quaternion rot;

    private Quaternion referenceRotation = Quaternion.identity;

    void Start () {

        if (!(photonView.isMine))
        {
            return;
        }

        Camera.main.transform.SetParent(transform);

        gyroEnabled = AttachGyro();		

    }
    
    private bool AttachGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            transform.rotation = Quaternion.Euler(90f, 90f, 0);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    private void DetachGyro()
    {
        gyroEnabled = false;
    }

    void Update()
    {
        if (!(photonView.isMine))
        {
            return;
        }

        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot * referenceRotation;
        }


    }

    public void Calibrate()
    {
        StartCoroutine(RecalculateRotation(1));
        //referenceRotation = Quaternion.Inverse(transform.rotation) * Quaternion.Inverse(Quaternion.identity);
    }

    IEnumerator RecalculateRotation(float t)
    {
        gyroEnabled = false;
        //transform.localRotation = Quaternion.Euler(0, transform.localRotation.y, 0);
        referenceRotation = Quaternion.Euler(0, transform.localRotation.y, 0);
        yield return new WaitForSeconds(t);
        gyroEnabled = true;

        yield break;
    }
}
