using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

    public Button buttonStart;



	void FixedUpdate () {

        Button start = buttonStart.GetComponent<Button>();
        start.onClick.AddListener(loadGameScene);
		
	}

    void loadGameScene ()
    {
        SceneManager.LoadScene(1); // LOAD MAIN GAME
    }
}
