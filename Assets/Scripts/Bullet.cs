using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float speed = 5f;
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
    }
}
