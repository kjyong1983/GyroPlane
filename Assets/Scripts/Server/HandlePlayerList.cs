using UnityEngine;
using UniWebServer;
using System.Linq;
using System.Collections.Generic;

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
        public int prop1;
        public int prop2;
    }

    public void HandleRequest(Request request, Response response)
    {
        response.statusCode = 200;
        response.message = "OK.";
        foreach (var player in PhotonNetwork.playerList)
        {
            Debug.LogFormat("User ID: {0}", player.UserId);
        }
        List<Player> playerList = new List<Player>();
        foreach (var player in PhotonNetwork.playerList)
        {
            var p = new Player
            {
                userId = player.UserId,
                score = player.GetScore()
            };
            if (player.CustomProperties != null)
            {
                object prop1;
                if (player.CustomProperties.TryGetValue("prop1", out prop1))
                {
                    p.prop1 = (int)prop1;
                }
                object prop2;
                if (player.CustomProperties.TryGetValue("prop2", out prop2))
                {
                    p.prop2 = (int)prop2;
                }
            }
            playerList.Add(p);
        }
        Debug.Log(playerList);
        Debug.Log(playerList.Count);
        
        response.Write(JsonUtility.ToJson(new PlayerListResponse { playerList = playerList.ToArray() }));
    }
}
