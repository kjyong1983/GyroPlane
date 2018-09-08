using UnityEngine;
using UniWebServer;
using System.Linq;

[RequireComponent(typeof(EmbeddedWebServerComponent))]
public class HandlePlayerList : MonoBehaviour, IWebResource
{
    public string path = "/playerList";

    EmbeddedWebServerComponent server;

    void Start()
    {
        server = GetComponent<EmbeddedWebServerComponent>();
        server.AddResource(path, this);
    }

    [System.Serializable]
    struct PlayerListResponse
    {
        public string[] playerList;
    }

    public void HandleRequest(Request request, Response response)
    {
        Debug.LogFormat("HandleRequest(): Player User ID = {0}", PhotonNetwork.player.UserId);
        foreach (var player in PhotonNetwork.playerList)
        {
            Debug.LogFormat("User ID: {0}", player.UserId);
        }

        response.statusCode = 200;
        response.message = "OK.";
        var playerList = new PlayerListResponse
        {
            playerList = PhotonNetwork.playerList.Select(e => e.UserId).ToArray()
        };
        Debug.Log(JsonUtility.ToJson(playerList));
        response.Write(JsonUtility.ToJson(playerList));
    }
}
