using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text Score;
    public Text Health;

    private string score;
    private string health;

    public int TotalScore = 0;

    public int TotalHealth = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        health = "Health: " + TotalHealth.ToString();
        score = "Score: " + TotalScore.ToString();

        Score.text = score;
        Health.text = health;

        if (TotalHealth <= 25)
        {
            Health.color = Color.red;
        }

        if (TotalHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }

	}
}
