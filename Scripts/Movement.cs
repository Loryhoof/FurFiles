using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public Rigidbody rb;

    private float maxStamina = 100f;
    public float stamina = 100f;
    public float staminaRate = 0.1f;
    public float staminaRecover = 0.5f;

    public float gravity = 10;


    void Update ()
    {
        stamina += staminaRecover * Time.deltaTime;

        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }

    }


    void FixedUpdate() {


        if (isLocalPlayer == true)
        {

            if (Input.GetKey("w") || Input.GetMouseButton(3))
            {

                rb.velocity = transform.forward * 1;
            }

            if (Input.GetKey("w") && (Input.GetKey(KeyCode.LeftShift)))
            {
                sprint();
            }

            if (Input.GetKey("s"))
            {

                rb.velocity = transform.forward * -0.5f;
            }

            if (Input.GetKey("a"))
            {

                rb.velocity = transform.right * -1;
            }

            if (Input.GetKey("d"))
            {

                rb.velocity = transform.right * 1;
            }

            if (Input.GetKey("e"))
            {
                transform.Rotate(0, 3, 0);
            }

            if (Input.GetKey("q"))
            {
                transform.Rotate(0, -3, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (transform.position.y < 1.1f)
                {
                    //rb.AddForce(0, 50, 0);
                    rb.velocity = transform.up * 5;
                }
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync(0);
            }

            /*if (Input.GetKey(KeyCode.LeftControl))
            {
                rb.AddForce(0, -100, 0);
            }*/

        }
		
	}

    void sprint ()
    {
        stamina -= staminaRate;

        if (stamina > 0)
        {
            rb.velocity = transform.forward * 2;
        }

        else if (stamina <= 0)
        {
            stamina = 0;
        }

    }
}

  



