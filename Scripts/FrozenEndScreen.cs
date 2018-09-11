using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrozenEndScreen : MonoBehaviour {

    public Button menuButton;

	
	// Update is called once per frame
	void Update () {

        Button menu = menuButton.GetComponent<Button>();

        menu.onClick.AddListener(toMenu);
		
	}

    void toMenu ()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
