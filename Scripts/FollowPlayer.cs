using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    public float zoomSpeed = 0.01f;
    public float zoomSpeedY = 0.5f;

	
	void Update () {

        transform.position = player.position + offset;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset.z-= zoomSpeed;
            offset.y-= zoomSpeedY;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset.z+= zoomSpeed;
            offset.y+= zoomSpeedY;
        }



    }
}
