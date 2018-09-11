using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {

    public AudioSource switchSound;

    public int maxHealCount = 2;
    public int maxHeal = 70;
    public int UIStatus;

    public int maxEnergyCount = 5;
    public int maxEnergyBoost = 80;

    public float Wood = 0f;

    public float rawLamb = 0f;
    //public float cookedLamb = 0f;

    public GameObject spear;
    public GameObject hatchet;
    public GameObject rifle;
    public GameObject launcher;

    public GameObject Slot01;
    Image IMG01;

    EnvDetails envDetails;
    HitHatchet hitHatchet;
    



    void Start ()
    {
        Slot01.transform.Find("/Slot01");
        IMG01 = Slot01.gameObject.GetComponent<Image>();
    }




    void Update () {

        switchSound.pitch = Random.Range(1f, 1.25f);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            toggleSpear();
          
            hatchet.SetActive(false);
            rifle.SetActive(false);
            launcher.SetActive(false);
            
     

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            toggleHatchet();
           
            spear.SetActive(false);
            rifle.SetActive(false);
            launcher.SetActive(false);
            

           

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            toggleRifle();
            
            spear.SetActive(false);
            hatchet.SetActive(false);
            launcher.SetActive(false);
            

          

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
          
            toogleLauncher();
            spear.SetActive(false);
            hatchet.SetActive(false);
            rifle.SetActive(false);
        
        }                                                                 //rocketlauncher thingy


        //Button heal = healButton.GetComponent<Button>();
        envDetails = FindObjectOfType<EnvDetails>();
        //heal.onClick.AddListener(healSelf);

        //if (Input.GetKey(healNumber)) {

        //    healSelf();
        //}
		
	}

    public void healSelf ()
    {
        if (maxHealCount <= 0)
        {
            maxHealCount = 0;
            maxHeal = 0;
        }

        if (maxHealCount > 0)
        {
            maxHealCount--;
            envDetails.health += maxHeal;
        }


    }

    public void energizeSelf()
    {
        if (maxEnergyCount <= 0)
        {
            maxEnergyCount = 0;
            maxEnergyBoost = 0;
        }

        if (maxEnergyCount > 0)
        {
            maxEnergyCount--;
            envDetails.stamina += maxEnergyBoost;
        }
    }

    public void toggleSpear ()
    {

        if (UIStatus == 0)
        {
            UIStatus = 1;
            spear.SetActive(true);
            switchSound.Play();
        } else
        {
            spear.SetActive(false);
            UIStatus = 0;
        }

    }

    public void toggleHatchet()
    {
        if (UIStatus == 0)
        {
            UIStatus = 1;
            hatchet.SetActive(true);
            switchSound.Play();
        } else {
            hatchet.SetActive(false);
            UIStatus = 0;
        }
    }

    public void toggleRifle()
    {
        if (UIStatus == 0)
        {
            UIStatus = 1;
            rifle.SetActive(true);
            switchSound.Play();
        } else
        {
            rifle.SetActive(false);
            UIStatus = 0;
        }
    }

    public void toogleLauncher()
    {
        if (UIStatus == 0)
        {
            UIStatus = 1;
            launcher.SetActive(true);
            switchSound.Play();
        }
        else
        {
            launcher.SetActive(false);
            UIStatus = 0;
        }

    }

    public void toggleSlot01()
    {
        //Slot01.gameObject.SetActive(false);
        IMG01.enabled = !IMG01.enabled;
    }

}
