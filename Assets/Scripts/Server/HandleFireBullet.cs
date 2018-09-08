using UnityEngine;
using UniWebServer;

[RequireComponent(typeof(EmbeddedWebServerComponent))]
public class HandleFireBullet : MonoBehaviour, IWebResource
{
    public string path = "/fireBullet";

    EmbeddedWebServerComponent server;

    [System.Serializable]
    struct FireBulletRequest
    {
        public float y;
        public float x;
    }

    void Start()
    {
        server = GetComponent<EmbeddedWebServerComponent>();
        server.AddResource(path, this);
    }
    
    public void HandleRequest(Request request, Response response)
    {
        response.statusCode = 200;
        response.message = "OK.";
        var fireBullet = JsonUtility.FromJson<FireBulletRequest>(request.body);
        var rot = Quaternion.Euler(fireBullet.x, fireBullet.y, 0);
        var dir = rot * Vector3.forward;
        Server.Instance.airplaneController.photonView.RPC("InstantiateBullet", PhotonTargets.All, Vector3.zero, dir);
        response.Write("Fire in the hole~~~~");
    }
}
