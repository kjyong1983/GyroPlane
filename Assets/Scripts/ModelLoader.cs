using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLoader : /*Photon.*/MonoBehaviour {

    public GameObject[] Prefabs;
    [SerializeField] int rndNum;
    [SerializeField] GameObject newObject;

    void Start () {

        rndNum = Random.Range(0, Prefabs.Length);
        GetModel();
    }

    //[PunRPC]
    //void GetRandom()
    //{
    //    rndNum = Random.Range(0, Prefabs.Length);
    //}

    public void GetModel()
    {
        newObject = Instantiate(Prefabs[rndNum], transform);
        newObject.transform.position = new Vector3(0, transform.position.y - 2.5f, transform.position.z - 5f);
    }
}
