using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Interactable : NetworkBehaviour {

    public float radius = 1f;

    public Transform player;
    public Transform campFire;

    public bool detected = false;

    EnvDetails envDetails;


    void FixedUpdate ()
    {

        if (Vector3.Distance(campFire.position, this.transform.position) < radius)
        {
            envDetails = FindObjectOfType<EnvDetails>();

            if (isLocalPlayer)
            {
                envDetails.celsiusTemp += 0.01f;
            }

        }

    }
}
