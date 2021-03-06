﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : Photon.MonoBehaviour {

    private float speed = 3f;
    const float DEFAULTSPEED = 3f;
    public bool isSpeedUp = false;
    public bool isSpeedDown = false;
    public bool isFiring = false;

    float fireRate = 0.2f;
    float bulletTimer = 0f;

    public GameObject bullet;
    public string nickName;

    public int health = 10;

    int yaw = 0;
    int pitch = 0;
    int roll = 0;

    bool debug = false;

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
        FindObjectOfType<NickNameInput>().controller = this;
        //FindObjectOfType<CalibrateHandler>().controller = this;

    }

    //show nickname
    void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 25;

        Vector2 worldPoint = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(worldPoint.x - 100, (Screen.height - worldPoint.y) - 50, 200, 100), nickName, guiStyle);
    }

    void Update () {

        if (!(photonView.isMine))
        {
            return;
        }

        //Debug.Log(speed);

        if (Application.platform == RuntimePlatform.Android)
        {
            UpdateSpeed();
        }

        if (Application.isEditor)
        {
            //if you are playing with pc
            GetKeyBoardInput();
        }

        if (debug)
        {
            speed = 0;
        }

        //move towards as camera view is watching
        transform.position = transform.position + Camera.main.transform.forward * Time.deltaTime * speed;

        //FireBullet();
        Vector3 moveDir = (transform.forward).normalized;
        FireBullet(transform.position, moveDir);

        if (health <= 0 )
        {
            GetComponent<ParticlePlayer>().PlayEffect(0);
            Destroy(gameObject,5f);
        }


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
        GetComponent<GyroController>().AttachGyro();
    }
    
    private void FireBullet(Vector3 pos, Vector3 dir)
    {
        if (!photonView.isMine)
            return;


        bulletTimer += Time.deltaTime;
        if (isFiring)
        {
            if (bulletTimer >= fireRate)
            {
                InstantiateBullet(pos, dir);
                photonView.RPC("InstantiateBullet", PhotonTargets.OthersBuffered, pos, dir);
                //var bulletObj = Instantiate(bullet, pos, Quaternion.Euler(dir));
                //bullet.GetComponent<Bullet>().moveDir = dir;
                bulletTimer = 0;
            }
        }


    }

    [PunRPC]
    private void InstantiateBullet(Vector3 pos, Vector3 dir)
    {
        var bulletObj = Instantiate(bullet, pos, Quaternion.Euler(dir));
        bullet.GetComponent<Bullet>().moveDir = dir;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            GetComponent<ParticlePlayer>().PlayEffect(0);
            health -= 5;
        }
    }

}

