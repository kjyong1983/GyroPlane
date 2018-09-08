using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickNameInput : MonoBehaviour {

    InputField inputField;
    public AirplaneController controller;
	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
        StartCoroutine(ApplyName());
    }
    
    IEnumerator ApplyName()
    {
        while (true)
        {
            if (PhotonNetwork.player != null && inputField != null && controller != null)
            {
                PhotonNetwork.player.NickName = inputField.text;
                controller.nickName = inputField.text;
            }
            yield return new WaitForSeconds(2);
        }

    }

}
