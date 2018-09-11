using UnityEngine;

public class animHatchet : MonoBehaviour
{

    public Animator anim;


    ActionBar actionBar;

    public bool animPlaying = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        actionBar = FindObjectOfType<ActionBar>();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && actionBar.UIStatus != 0)
        {
            if (animPlaying == false)
                anim.Play("hatchetWalk");
        }


        if (Input.GetMouseButton(0) && actionBar.UIStatus != 0)
        {
            animPlaying = true;
            anim.Play("Hatchet"); // ANIMATION
            this.GetComponentInChildren<Collider>().enabled = true;
        }
        else {
            this.GetComponentInChildren<Collider>().enabled = false;
            //anim.StopPlayback();
            animPlaying = false;
        }

        if (Input.GetMouseButtonUp(0) && actionBar.UIStatus != 0)
        {
            animPlaying = false;
        }



    }
}
