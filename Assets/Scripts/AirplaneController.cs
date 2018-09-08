using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : Photon.MonoBehaviour {

    private float speed = 3f;
    const float DEFAULTSPEED = 3f;
    public bool isSpeedUp = false;
    public bool isSpeedDown = false;

    int yaw = 0;
    int pitch = 0;
    int roll = 0;

    // Use this for initialization
    void Start () {
        if (!(photonView.isMine))
        {
            return;
        }

        transform.position = new Vector3(0, 20, 0);

        FindObjectOfType<AccelHandler>().controller = this;
        FindObjectOfType<FireHandler>().controller = this;
        FindObjectOfType<BrakeHandler>().controller = this;
        //FindObjectOfType<CalibrateHandler>().controller = this;

    }

    // Update is called once per frame
    void Update () {

        if (!(photonView.isMine))
        {
            return;
        }

        Debug.Log(speed);


        if (Application.platform == RuntimePlatform.Android)
        {
            UpdateSpeed();
        }

        if (Application.isEditor)
        {
            //if you are playing with pc
            GetKeyBoardInput();
        }
        //#if UNITY_ANDROID
        //        UpdateSpeed();
        //#endif

        //#if UNITY_EDITOR
        //        //if you are playing with pc
        //        GetKeyBoardInput();
        //#endif

        //move towards as camera view is watching
        transform.position = transform.position + Camera.main.transform.forward * Time.deltaTime * speed;
    }

    public void GetKeyBoardInput()
    {
        if (Input.GetKey(KeyCode.W)) isSpeedUp = true;
        else isSpeedUp = false;

        if (Input.GetKey(KeyCode.S)) isSpeedDown = true;
        else isSpeedDown = false;

        if (Input.GetKey(KeyCode.A)) yaw = -2;
        else if (Input.GetKey(KeyCode.D)) yaw = 2;
        else yaw = 0;

        if (Input.GetKey(KeyCode.Space)) pitch = -2;
        else if (Input.GetKey(KeyCode.LeftControl)) pitch = 2;
        else pitch = 0;

        if (Input.GetKey(KeyCode.Q)) roll = 2;
        else if (Input.GetKey(KeyCode.E)) roll = -2;
        else roll = 0;

        transform.Rotate(pitch, yaw, roll);

    }

    public void UpdateSpeed()
    {
        if (isSpeedUp)
        {
            speed = Mathf.Lerp(speed, 10f, Time.deltaTime * 2f);
           
        }
        else if (isSpeedDown)
        {
            speed = Mathf.Lerp(speed, 0.5f, Time.deltaTime * 2f);
           
        }
        else
            speed = Mathf.Lerp(speed, DEFAULTSPEED, Time.deltaTime * 5f);
    }

    public void CalibrateGyro()
    {
        //GetComponent<GyroControl>().Calibrate();
        GetComponent<GyroController>().AttachGyro();
    }


}

