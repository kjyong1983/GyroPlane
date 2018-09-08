using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatchmaker : MonoBehaviour {

    public GameObject photonObject;

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
        PhotonNetwork.CreateRoom(null, ro, null);
    }

    void OnJoinedRoom()
    {

        GameObject player = PhotonNetwork.Instantiate(
            photonObject.name,
            new Vector3(0, 0, 0),
            Quaternion.identity, 
            0);

    }
    


}
