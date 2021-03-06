﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float speed = 25f;
    public Vector3 moveDir;

	void Start () {
        Destroy(gameObject, 5f);
	}
	
	void Update () {

        transform.position += moveDir * speed * Time.deltaTime;
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        var other = collision.gameObject.GetComponentInParent<AirplaneController>();
        if (other != null)
        {

            Debug.Log(other.gameObject.name + " " + "health : " + other.health);
        }
        Destroy(gameObject);
    }
}
