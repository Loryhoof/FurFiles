using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public Text heightText;

    public Text fuelText;
    public Text thrustText;


    PlayerMovement playerMovement;
    


    void Start()
    {

        //playerMovement = FindObjectOfType<PlayerMovement>();

    }


    void Update()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        scoreText.text = player.rotation.ToString(".0001");
        heightText.text = player.position.y.ToString("0" + " ft");

        fuelText.text = playerMovement.fuel.ToString("0" + " Fuel");
        thrustText.text = playerMovement.jumpForce.ToString("0");




    }
}
