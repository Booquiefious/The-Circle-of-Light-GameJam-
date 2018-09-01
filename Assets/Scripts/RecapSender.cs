using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecapSender : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int newHighScore;
    public int oldHighScore;

}
