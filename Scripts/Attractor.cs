using UnityEngine;

public class Attractor : MonoBehaviour {

    public Rigidbody rb;

    public float rotationSpeed = 0.5f;

    private float orbitalSpeed = 100f;

    void FixedUpdate()
    {

        transform.Rotate(0, rotationSpeed, 0);

        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
            {
                Attract(attractor);

            }
        }
    }

    void Attract (Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);

    }
}
