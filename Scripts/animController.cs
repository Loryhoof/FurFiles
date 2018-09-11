using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {
    
    public Animator anim;
    public AudioSource whoosh,
                       throwHit;

    public bool attackAnimPlaying = false;

    public LayerMask interactable;

    Vector3 standartPos;
    Quaternion standartRot;


    private float throwSpeed = 10f;

    ActionBar actionBar;
    Rigidbody rb;
    Camera cam;
    DetailsUI detailsUI;


    private bool throwRdy = false,
                 charging = false;

    public bool thrown = false;



    public void stopAnim ()
    {
        throwRdy = true;
        anim.speed = 0;

    }

    public void attackNotPlaying()
    {
        attackAnimPlaying = false;
    }

    public void whooshPlay ()
    {
        whoosh.pitch = Random.Range(1.1f, 1.25f);
        whoosh.Play(); // SOUND EFFECT
    }

	void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        standartPos = this.transform.localPosition;
        standartRot = this.transform.localRotation;
    }

    void Update() {

       
        actionBar = FindObjectOfType<ActionBar>();
        detailsUI = FindObjectOfType<DetailsUI>();


        if (thrown == true)
        {
            pickUp();
        }


        if (Input.GetMouseButton(1) && actionBar.UIStatus != 0 && throwRdy == false) //Charges spear 
        {

            charging = true;

            if (!throwRdy)
            {
                anim.Play("spearThrow");
            }


        }

        if (Input.GetMouseButtonUp(1) && thrown == false  && throwRdy == true)
        {
            charging = false;
            throwRdy = false;
            
            anim.speed = 1;
            
        }


        if (Input.GetMouseButton(0) && actionBar.UIStatus != 0 && throwRdy == false)
        {
            attackAnimPlaying = true;
            //whoosh.pitch = Random.Range(0.8f, 1.2f);
            //whoosh.Play(); // SOUND EFFECT

            anim.Play("spearAttack"); // ANIMATION
            

            this.GetComponent<Collider>().enabled = true;

        } else
        {
            if (thrown == true)
                this.GetComponent<Collider>().enabled = true;
            else
            {
                this.GetComponent<Collider>().enabled = false;
                attackAnimPlaying = false;
            }

            if (Input.GetMouseButtonUp(0))
                attackAnimPlaying = false;
                 
            


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && actionBar.UIStatus != 0)
            {
                if (!throwRdy && attackAnimPlaying == false && charging == false)
                {
                    anim.Play("spearWalk");

                }
                
            }
        }
            


    }

    void FixedUpdate ()
    {
        if (thrown == true)
        {

            throwSpeed -= 0.1f;

            anim.enabled = false;

           
            if (throwSpeed <= 0)
            {
                rb.useGravity = true;
            }

            if (throwSpeed >= 0)
            {
                transform.Translate(Vector3.forward * throwSpeed * Time.deltaTime, Space.Self);
            }
        }
    }

    void LateUpdate ()
    {
       

        if (Input.GetMouseButtonDown(0) && throwRdy == true && charging == true) //Throws the spear forward
        {
            anim.speed = 1;
            throwRdy = false;
            transform.parent = null;
            //anim.Stop();
            thrown = true;
            actionBar.toggleSlot01(); // Slot01 Picture Toggle

            whooshPlay();
            
        }
    }


    public void OnTriggerEnter(Collider other)
    {

        if (thrown == true)
        {
            if (other.gameObject.tag != "Player")
            {
                throwSpeed = 0;
                rb.useGravity = false;
                rb.isKinematic = true;
                throwHit.Play();
            }


            if (other.gameObject.tag == "Land")
            {
                throwSpeed = 0;
            }
        }
       
    }

    void pickUp ()
    {


        float x = Screen.width / 2;
        float y = Screen.height / 2;


        Ray ray = cam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2f, interactable))
        {
            
            if (Input.GetKeyDown(KeyCode.E)) //pressing E on object
            {
                if (thrown == true) // Spear was thrown in the World and selected by Raycast
                {
                    
                    GameObject wepCam = GameObject.FindGameObjectWithTag("WeaponCam");
                    this.transform.parent = wepCam.transform;
                    pickedUp(); //standart values before throwing spear
                }

            }
        }

       
    }

    void pickedUp ()
    {
        thrown = false;
        this.transform.localPosition = standartPos;
        this.transform.localRotation = standartRot;
        throwSpeed = 10;
        rb.isKinematic = false;
        rb.useGravity = false;
        anim.enabled = true;
        actionBar.toggleSlot01(); // Slot01 Picture Toggle
        
        
    }




}
