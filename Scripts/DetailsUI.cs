using UnityEngine;
using UnityEngine.UI;

public class DetailsUI : MonoBehaviour {

    public Transform player;
    
    private float maxHitpoint = 100f; // MAX HEALTH

    //player_UI
    public Text staminaText;
    public Text healthText;
    public Text temperatureText;
    public Text localTime;

   

    public Slider healthBar;
    public Slider staminaBar;


    //PLAYER_INVENTORY
    public Text amountBandage;
    public Text amountAdrenalin;
    public Text amountWood;
    public Text ownWoodinCampfire;
    public Text rawLamb;

    //CAMPFIRE
    public Text campfireWoodAmount;


    //JET_HUD
    public Text heading;
    public Text altitude;
    public Text velocity;

    public Slider thrust;



    


    

    // // // // // // 
    Movement movement;
    EnvDetails envDetails;
    CameraMovement camMovment;
    ActionBar actionBar;
    Campfire campfire;
    JetFly jetFly;
    jetCam jetCam;

    void Start ()
    {
        UpdateHealthBar();
        
    }


    void Update() {

        if (Input.GetKey(KeyCode.Escape))
        {
            //Application.Quit();
        }

        localTime.text = System.DateTime.Now.ToString("hh:mm tt"); //LOCAL TIME

        movement = FindObjectOfType<Movement>();
        envDetails = FindObjectOfType<EnvDetails>();
        camMovment = FindObjectOfType<CameraMovement>();
        actionBar = FindObjectOfType<ActionBar>();
        campfire = FindObjectOfType<Campfire>();
        jetFly = FindObjectOfType<JetFly>();
        jetCam = FindObjectOfType<jetCam>();
        

        UpdateHealthBar();
        UpdateStaminaBar();
        UpdateThrustBar();

        staminaText.text = envDetails.stamina.ToString("0");
        healthText.text = envDetails.health.ToString("0");
        temperatureText.text = envDetails.celsiusTemp.ToString("0" + "°C");

        amountBandage.text = actionBar.maxHealCount.ToString("0");
        amountAdrenalin.text = actionBar.maxEnergyCount.ToString("0");
        amountWood.text = actionBar.Wood.ToString("0");
        ownWoodinCampfire.text = actionBar.Wood.ToString("0");
        rawLamb.text = actionBar.rawLamb.ToString("0");

        campfireWoodAmount.text = campfire.campfireInventoryWood.ToString("0"); // Wood-Inventory of campfire

        heading.text = jetCam.forwardRot.ToString("0" + "°");
        altitude.text = jetFly.hit.transform.position.y.ToString("0");
        velocity.text = jetFly.hit.rigidbody.velocity.z.ToString("0");
        
        


        //if (camMovment.hit.collider.name != "Ground")
        //{
        //    focusedText.text = camMovment.hit.collider.name.ToString();
        //}

    }

    void UpdateHealthBar()
    {
        float ratio = envDetails.health / maxHitpoint;
        healthBar.value = ratio;

    }

    void UpdateStaminaBar()
    {
        float ratio = envDetails.stamina / maxHitpoint;
        staminaBar.value = ratio;

        if (envDetails.stamina < 0)
        {
            envDetails.stamina = 0f;
            envDetails.health -= 0.075f;
        }

        if (envDetails.stamina < 100)
        {
            envDetails.stamina += 0.025f;
        }

        if (envDetails.stamina >= 100)
        {
            envDetails.stamina = 100;
        }
        
    }

    

    void UpdateThrustBar()
    {
        float ratio = jetFly.velocity / 50;
        thrust.value = ratio;
    }

    public void UpdateStackSize(IClickable clickable) //Inventory Property
    {
        if(clickable.MyCount > 1)
        {
            clickable.MyStackText.text = clickable.MyCount.ToString();
            clickable.MyStackText.color = Color.white;
            clickable.MyIcon.color = Color.white;

        } else
        {
            clickable.MyStackText.color = new Color(0, 0, 0, 0);
        }

        if (clickable.MyCount == 0)
        {
            clickable.MyIcon.color = new Color(0, 0, 0, 0);
            clickable.MyStackText.color = new Color(0, 0, 0, 0);
        }

    }

}