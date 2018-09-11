using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float speed = 0.5f;
    public float viewDistance = 10f;

    public float attackDistance = 0.3f;

    public Transform player;
    public Transform enemy;

    public bool detected = false;

    EnvDetails envDetails;

    void FixedUpdate ()
    {

        if (detected == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.player.position, speed * Time.deltaTime);

            if (Vector3.Distance(this.transform.position, this.player.position) < attackDistance)
            {
                envDetails.health -= 0.5f;
            }
        }

        if (Vector3.Distance(enemy.position, this.player.position) < viewDistance)
        {
            envDetails = FindObjectOfType<EnvDetails>();

            detected = true;

        }

    }


}
