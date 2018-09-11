using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public AudioSource journalSound;
    public AudioSource journalClose;

    public GameObject JournalUI;
    int UIStatus;


    void Update()
    {


        if (Input.GetKeyDown("j") || Input.GetKeyDown(KeyCode.Tab))
        {
            if (UIStatus == 0)
            {
                journalSound.Play();
                UIStatus = 1;
                JournalUI.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = !Cursor.visible; test

            }
            else
            {
                journalClose.Play();
                JournalUI.SetActive(false);
                UIStatus = 0;
                Cursor.lockState = CursorLockMode.Confined;
                //Cursor.visible = false; // new test
            }

        }


    }
}

