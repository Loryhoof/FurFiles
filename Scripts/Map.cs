using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject MapUI;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("m"))
            MapUI.SetActive(true);
        else
            MapUI.SetActive(false);
	}
}
