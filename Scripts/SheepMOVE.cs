using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMOVE : MonoBehaviour {

    public Transform sheep;

    public float speed = 0.1f;
	
	// Update is called once per frame
	void Update () {

        sheep.transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
