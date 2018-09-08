using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLoader : MonoBehaviour {

    public GameObject[] Prefabs;

    void Start () {
        GetModel();
    }
    
    public void GetModel()
    {
        var newObject = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], transform);
        newObject.transform.position = new Vector3(0, transform.position.y - 2.5f, transform.position.z - 5f);
    }
}
