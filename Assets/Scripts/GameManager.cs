using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject SaveObject;
    public GameObject Player;
    public GameObject PauseMenu;

    public Text TimeText;

    public string time;

    public int sec = 0;
    public int min = 5;

    public bool isPaused = false;

    public GameObject RecapObject;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Use this for initialization
    void Start () {
        SaveObject.GetComponent<GameSave>().Load();
        StartCoroutine(TimeTec());
	}
	
	// Update is called once per frame
	void Update () {
        if (sec <= 9)
        {
            time = min.ToString() + ":0" + sec.ToString();
        }
        else
        {
            time = min.ToString() + ":" + sec.ToString();
        }
        TimeText.text = time;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            EscP();
        }
	}

    void EscP()
    {
        if (isPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PauseMenu.SetActive(false);
            Time.timeScale = 1.0F;
        }
    }

    IEnumerator TimeTec()
    {
        if (sec == 0)
        {
            sec = 59;
            min--;
        }else
        {
            sec--;
        }

        if (sec == 0 && min == 0)
        {
            EndGame();
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(TimeTec());
    }

    public void EndGame()
    {
        int tempCurrentScore = Player.GetComponent<PlayerController>().TotalScore;
        int tempHighScore = SaveObject.GetComponent<GameSave>().HighScore;

        GameObject r = (GameObject)Instantiate(RecapObject, transform.position, Quaternion.identity);

        r.GetComponent<RecapSender>().newHighScore = tempCurrentScore;
        r.GetComponent<RecapSender>().oldHighScore = tempHighScore;
        r.name = "Recap"; 

        if (tempCurrentScore < tempHighScore)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            SaveObject.GetComponent<GameSave>().HighScore = tempCurrentScore;
            SaveObject.GetComponent<GameSave>().Save();

            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}

