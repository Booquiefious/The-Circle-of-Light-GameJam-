using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionManager : MonoBehaviour {

    public float Lifetime = 5f;

	// Use this for initialization
	void Start () {
        StartCoroutine(Life());
	}

    IEnumerator Life()
    {
        yield return new WaitForSeconds(Lifetime);
        Destroy(gameObject);
    }
}
