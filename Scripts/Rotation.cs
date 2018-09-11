using UnityEngine;

public class Rotation : MonoBehaviour {

    public Rigidbody rb;

    public float orbitalSpeed = 100f;

    void FixedUpdate()
    {

        rb.velocity = transform.forward * orbitalSpeed;

    }
}
