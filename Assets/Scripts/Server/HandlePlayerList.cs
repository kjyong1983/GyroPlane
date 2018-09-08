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
        public Player[] playerList;
    }

    [System.Serializable]
    struct Player
    {
        public string userId;
        public int score;
    }

    public void HandleRequest(Request request, Response response)
    {
        response.statusCode = 200;
        response.message = "OK.";
        var playerList = new PlayerListResponse
        {
            playerList = PhotonNetwork.playerList.Select(e => new Player { userId = e.UserId, score = e.GetScore() }).ToArray()
        };
        response.Write(JsonUtility.ToJson(playerList));
    }
}
