using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text HighScoreText;
    public Text VersionNumber;

    public GameObject SaverObject;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

         SaverObject.GetComponent<GameSave>().Load();
         int score = SaverObject.GetComponent<GameSave>().HighScore;
         if (score == 0)
         {
             SaverObject.GetComponent<GameSave>().HighScore = 100;
             SaverObject.GetComponent<GameSave>().Save();
             score = SaverObject.GetComponent<GameSave>().HighScore;

            HighScoreText.text = "HighScore: " + score;
        } else
        {
            HighScoreText.text = "HighScore: " + score;
        }

        VersionNumber.text = "Version: v" + Application.version;
         
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
