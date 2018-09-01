using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject ball;

    public Transform startPos;

	// Use this for initialization
	void Start () {
		if (startPos == null)
        {
            startPos = gameObject.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Fire();
        }
	}

    public void Fire()
    {
        GameObject Ball = (GameObject)Instantiate(ball, startPos.transform.position, startPos.transform.rotation);
    }
}
