using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapManager : MonoBehaviour {

    public Text HighScoreText;
    public Text CurrentScoreText;

    public GameObject RecapSender;

    public int newScore;
    public int oldScore;

    public int scoreCount;

    // Use this for initialization
    void Start () {
        RecapSender = GameObject.Find("Recap");

        newScore = RecapSender.GetComponent<RecapSender>().newHighScore;
        oldScore = RecapSender.GetComponent<RecapSender>().oldHighScore;

        HighScoreText.text = "HighScore: " + oldScore.ToString();
        StartCoroutine(ChangeScore());
	}

    void ScoreMath()
    {
        if (newScore >= oldScore)
        {
            StartCoroutine(NewScoreBigger());
        }
        else
        {
            StartCoroutine(NewScoreSmaller());
        }
    }

    IEnumerator NewScoreBigger()
    {
        CurrentScoreText.text = "New HighScore: " + scoreCount.ToString();
        HighScoreText.text = "Old HighScore: " + oldScore.ToString();
        HighScoreText.color = Color.red;
        CurrentScoreText.color = Color.green;

        yield return new WaitForSeconds(3f);

        End();
    }

    IEnumerator NewScoreSmaller()
    {
        CurrentScoreText.text = "Old HighScore: " + scoreCount.ToString();
        HighScoreText.text = "Score: " + oldScore.ToString() + "| Better luck next time.";
        HighScoreText.color = Color.green;
        CurrentScoreText.color = Color.red;

        yield return new WaitForSeconds(3f);

        End();
    }

    IEnumerator ChangeScore()
    {
        CurrentScoreText.text = "Score: " + scoreCount.ToString();

        if (scoreCount < newScore)
        {
            scoreCount += 5;
        } else if (scoreCount == newScore)
        {
            ScoreMath();
        }

        yield return new WaitForSeconds(.0000000001f);
        StartCoroutine(ChangeScore());
    }

    void End()
    {
        Destroy(RecapSender);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
