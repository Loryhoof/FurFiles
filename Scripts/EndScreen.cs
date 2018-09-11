using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public Button quitButton;


	public void Update () {

        Cursor.visible = true;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);
        }

        Button quit = quitButton.GetComponent<Button>();
        quit.onClick.AddListener(QuitGame);



    }

    public void FixedUpdate ()
    {
        Cursor.visible = true;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }

    void QuitGame ()
    {
        Application.Quit();
    }

}
