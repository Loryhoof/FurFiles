using UnityEngine;

public class DayNight : MonoBehaviour {

    public float cycleTime;

	

	void FixedUpdate () {

        transform.RotateAround(Vector3.zero, Vector3.right, cycleTime * Time.deltaTime);
        //transform.Rotate(new Vector3(cycleTime * Time.deltaTime, 0, 0));
        transform.LookAt(Vector3.zero);
        
	}
}
