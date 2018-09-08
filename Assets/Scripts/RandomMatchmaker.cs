using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatchmaker : MonoBehaviour {

    public GameObject photonObject;

    //public GameObject[] photonObject;
    //public GameObject gyroCam;
    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }
    
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        RoomOptions ro = new RoomOptions();
        ro.PublishUserId = true;
        PhotonNetwork.CreateRoom("defaultRoom", ro, null);
    }

    void OnJoinedRoom()
    {
        //int rndNum = Random.Range(0, photonObject.Length);

        GameObject player = PhotonNetwork.Instantiate(
//            photonObject[rndNum].name,
            photonObject.name,
            new Vector3(0, 0, 0),
            Quaternion.identity, 
            0);

        //PhotonNetwork.Instantiate(gyroCam.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
        
        //GameObject mainCamera = GameObject.FindWithTag("MainCamera");

        //player.transform.SetParent(mainCamera.transform.parent);

    }
    


}
