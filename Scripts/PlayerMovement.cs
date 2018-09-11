using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float jumpForce = 0f;
    public float minHeight = -5f;

    public float gravity = 9.81f;
    public float fuel = 1000f;
    private float authority = 0.00f;

    private float maxAuthority = 0.2f;
    private float minAuthority = 0.0f;

    private float authorityMultiplier = 0.001f;

    private float vertSpeed = 0f;
    private float horSpeed = 0f;



    void FixedUpdate() {




        rb.AddForce(0, -gravity, 0);
        rb.velocity = transform.up * jumpForce / 5;



        //CONTROLLS
        ///////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetKey("a"))
        {

            
            transform.Rotate(0, 0, authority);

        }

        if (Input.GetKey("d"))
        {

            
            transform.Rotate(0, 0, -authority);
            
        }

        if (Input.GetKey("w"))
        {
            transform.Rotate(authority, 0, 0);
        }

        if (Input.GetKey("s"))
        {
            transform.Rotate(-authority, 0, 0);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            jumpForce++;
            authority += authorityMultiplier;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            jumpForce--;
            authority -= authorityMultiplier;
        }

        if (Input.GetKey("y") || Input.GetKey("z"))
        {
            authority = maxAuthority;
            jumpForce = 1000;
        }

        if (Input.GetKey("x"))
        {
            authority = minAuthority;
            jumpForce = 0;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////



        if (jumpForce >= 100)
        {
            jumpForce = 100;
        }

        if (jumpForce <= 0)
        {
            jumpForce = 0;
        }

        if (jumpForce > 1)
        {
            fuel-= jumpForce/100;
        }

        if (fuel <= 0)
        {
            jumpForce = 0;
            fuel = 0;
        }

        if (authority >= maxAuthority)
        {
            authority = maxAuthority;
        }

        if (authority <= minAuthority)
        {
            authority = minAuthority;
        }










        


        if (rb.position.y < minHeight)
        {
            FindObjectOfType<GameManager>().EndGame();

        }


    }
}
