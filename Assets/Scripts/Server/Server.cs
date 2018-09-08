using UnityEngine;

public class Server : Photon.MonoBehaviour
{
    void Start()
    {
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
        Debug.LogFormat("OnJoinedRoom(): Player User ID = {0}", PhotonNetwork.player.UserId);
        var cp = PhotonNetwork.player.CustomProperties;
        cp.Add("prop1", 1985);
        PhotonNetwork.player.SetCustomProperties(cp);
        cp = PhotonNetwork.player.CustomProperties;
        cp.Add("prop2", 19852);
        PhotonNetwork.player.SetCustomProperties(cp);
        foreach (var player in PhotonNetwork.playerList)
        {
            
            Debug.LogFormat("User ID: {0}", player.UserId);
        }
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        var cp = newPlayer.CustomProperties;
        cp.Add("prop1", 9999999);
        newPlayer.SetCustomProperties(cp);
        Debug.LogFormat("OnPhotonPlayerConnected(): Player User ID = {0}", PhotonNetwork.player.UserId);
        foreach (var player in PhotonNetwork.playerList)
        {
            //player.GetScore();
            Debug.LogFormat("User ID: {0}", player.UserId);
        }

        if (photonView != null)
        {
            
            photonView.RPC("SetCustomProp", newPlayer, 100);
            Debug.Log("photonView custom prop set!");
        }
        else
        {
            Debug.Log("photonView null!");
        }
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.LogFormat("OnPhotonPlayerDisconnected(): Player User ID = {0}", PhotonNetwork.player.UserId);
        foreach (var player in PhotonNetwork.playerList)
        {
            Debug.LogFormat("User ID: {0}", player.UserId);
        }
    }

    void OnLeftRoom()
    {
        Debug.LogFormat("OnLeftRoom(): Player User ID = {0}", PhotonNetwork.player.UserId);
    }
}
