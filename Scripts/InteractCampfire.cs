using UnityEngine;

public class InteractCampfire : MonoBehaviour {


    AudioSource fireSound;
    public LayerMask interactable;
    public GameObject campfireUI;
    private float radius = 2f;

    bool campfireIsLit = false;
    public bool atLitCampfire = false;

    Camera cam;
    ActionBar actionBar;
    Campfire campfire;
    EnvDetails envDetails;

    public GameObject campFireFlame;
    public GameObject campFireLight;



    void Start()
    {
        cam = Camera.main;
        actionBar = FindObjectOfType<ActionBar>();
        campfire = FindObjectOfType<Campfire>();
        envDetails = FindObjectOfType<EnvDetails>();
        fireSound = GetComponentInParent<AudioSource>();
        //Cursor.lockState = CursorLockMode.Locked;

    }

    void Update() {

        Cursor.lockState = CursorLockMode.Confined;


        if (campfire.campfireInventoryWood <= 0)
        {
            UnLitCampfire();
        }

        if (campfireIsLit == true)
        {
            isFreezing();
            fireSound.enabled = true;
            campfire.campfireInventoryWood -= 0.01f;
        }

        if (Input.GetKey("e"))
        {

            Cursor.lockState = CursorLockMode.Locked;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1f, interactable))
            {
                campfireUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else {
                campfireUI.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;

            }
        }
    }


    public void AddWoodToCampfire()
    {
        if (actionBar.Wood >= 10f)
        {
            actionBar.Wood -= 10f; // Subtracting Wood from own Inventory
            campfire.campfireInventoryWood += 10f; // Adding Wood to CampfireInventory
        }
        else
            return; // Maybe error message?

    }

    public void AddWoodToInventory()
    {
        if (campfire.campfireInventoryWood >= 10f)
        {
            campfire.campfireInventoryWood -= 10f;
            actionBar.Wood += 10f;
        }
        else
            return; // Maybe error message? Not enough wood in campfire, or just disable add/remove button
    }

 
    public void LightCampfire()
    {
        if (campfire.campfireInventoryWood >= 1)
        {
            
            campFireFlame.SetActive(true);
            campFireLight.SetActive(true);
            

            campfireIsLit = true;

        } else
        {
            UnLitCampfire();
        }
      
    }

    void UnLitCampfire()
    {
        //campfire.GetComponentInParent<AudioSource>().enabled = false;
        
        campFireFlame.SetActive(false);
        campFireLight.SetActive(false);

        campfireIsLit = false;
        atLitCampfire = false;
        fireSound.enabled = false;
    }

    public void isFreezing ()
    {
        if (Vector3.Distance(this.transform.position, cam.transform.position) < radius )
        {
            envDetails.celsiusTemp += 0.1f;
            
        } 
        
   
    }
      
}
