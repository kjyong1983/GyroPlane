using UnityEngine;

public class Server : MonoBehaviour
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
        PhotonNetwork.CreateRoom("defaultRoom", ro, null);
    }

    void OnJoinedRoom()
    {
        Debug.LogFormat("OnJoinedRoom(): Player User ID = {0}", PhotonNetwork.player.UserId);
        foreach (var player in PhotonNetwork.playerList)
        {
            Debug.LogFormat("User ID: {0}", player.UserId);
        }
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        Debug.LogFormat("OnPhotonPlayerConnected(): Player User ID = {0}", PhotonNetwork.player.UserId);
        foreach (var player in PhotonNetwork.playerList)
        {
            Debug.LogFormat("User ID: {0}", player.UserId);
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
