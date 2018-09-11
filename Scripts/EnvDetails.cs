using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;


public class EnvDetails : MonoBehaviour {

    public AudioSource dayAmbience,
                       nightAmbience;


    PostProcessingProfile PBhav;

  
    public Transform sun;

    public float celsiusTemp = 16f;

    public float health = 67f;
    public float maxHealth = 100f;

    public float stamina = 0f;
    public float maxStamina = 100f;

    public float decreaseRate = 0.0007f;
    public float maxDecreaseRate = 0.0025f;

    float increaseRate = 0.015f;

    InteractCampfire InterCamp;
    Camera Cam;
    


    void Start ()
    {
        InterCamp = FindObjectOfType<InteractCampfire>();
        Cam = Camera.main;
        PBhav = Cam.GetComponent<PostProcessingBehaviour>().profile;
    }

    void FixedUpdate () {

        temperature();
		
	}

    void temperature()
    {
        if (sun.transform.position.y < 30)
        {
            
            RenderSettings.sun.intensity = 0f;
            RenderSettings.fogDensity -= 0.00001f;

            if (sun.transform.position.y < 180)
            {
                celsiusTemp -= 0.015f;

                if (RenderSettings.reflectionIntensity > 0 && RenderSettings.ambientIntensity > 0)
                {
                    RenderSettings.reflectionIntensity =0;
                    RenderSettings.ambientIntensity = 0;
                } else
                {
                    dayAmbience.enabled = false;
                    nightAmbience.enabled = true;
                }
            }

            

        }

        if (sun.transform.position.y > -190)
        {
            celsiusTemp += increaseRate;


            RenderSettings.sun.intensity = 1.23f;
            RenderSettings.fogDensity += 0.0001f;
            
            if (RenderSettings.fogDensity >= 0.001f)
            {
                RenderSettings.fogDensity = 0.001f;
            }

            if (RenderSettings.reflectionIntensity < 1 && RenderSettings.ambientIntensity < 0.76f)
            {
                RenderSettings.reflectionIntensity += 0.01f;
                RenderSettings.ambientIntensity += 0.01f;

                if (RenderSettings.ambientIntensity >= 0.76f)
                {
                    RenderSettings.ambientIntensity = 0.76f;
                    
                    nightAmbience.enabled = false;
                    dayAmbience.enabled = true;
                }
                    

                if (RenderSettings.reflectionIntensity >= 1)
                    RenderSettings.reflectionIntensity = 1;
            }

        }


        if (celsiusTemp < -12)
        {
            health -= decreaseRate;
        }


        if (celsiusTemp >= 16)
            celsiusTemp = 16;

        if (health <= 30)
        {
            PBhav.vignette.enabled = true;
            var sets = PBhav.vignette.settings;
            sets.intensity = 1f;
            //.vignette.settings.color.r =
        } else
        {
            PBhav.vignette.enabled = false;
        }

        if (health >= 100)
        {
            health = maxHealth;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            health--;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(2); //DEATH
            
        }







    }

}
