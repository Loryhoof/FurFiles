using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChatBox : NetworkBehaviour {

    string chatMesssage = "Message";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isLocalPlayer)
            this.GetComponentInChildren<TextMesh>().text = chatMesssage;
		
	}
}
