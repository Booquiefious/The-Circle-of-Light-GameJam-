using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject Explotion;

    private MeshRenderer MR;
    private ParticleSystem PS;

    public float speed = 5f;

    public float Lifetime = 5f;

    public int damage = 25;

    public bool isEnemyBall = false;

    private bool hasdamaged = false;

	// Use this for initialization
	void Start () {
        MR = gameObject.GetComponent<MeshRenderer>();
        MR.enabled = true;
        PS = gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(Life());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);	
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Enemy" && isEnemyBall == false)
        {
            GameObject e = collision.gameObject;
            e.GetComponent<EnemyController>().Dead();
            StartCoroutine(Explode());
        } else if (collision.transform.tag == "Player" && isEnemyBall == true && hasdamaged == false)
        {
            hasdamaged = true;
            GameObject p = collision.gameObject;
            p.GetComponent<PlayerController>().TotalHealth -= damage;
            StartCoroutine(Explode());
        } else if (collision.transform.tag == "Ground")
        {
            StartCoroutine(Explode());
        } else if (collision.transform.tag == "Enemy" && isEnemyBall == true)
        {
            Emplode();
        }
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(Lifetime);
        StartCoroutine(Explode());
    }

    void Emplode()
    {
        Destroy(gameObject);
    }

    IEnumerator Explode()
    {
        MR.enabled = false;
        PS.Stop();
        Instantiate(Explotion, transform.position, transform.rotation);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
