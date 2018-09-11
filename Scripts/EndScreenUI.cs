using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenUI : MonoBehaviour {

    public Text dayCountText;

    EnvDetails envDetails;

	
	// Update is called once per frame
	void Update () {

        envDetails = FindObjectOfType<EnvDetails>();	
	}
}
