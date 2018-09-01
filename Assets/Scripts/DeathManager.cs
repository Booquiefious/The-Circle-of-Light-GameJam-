using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(TimedEvents());
    }

    IEnumerator TimedEvents()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
