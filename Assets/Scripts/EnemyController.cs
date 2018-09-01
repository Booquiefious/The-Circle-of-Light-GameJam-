using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    private NavMeshAgent NMA;

    public GameObject DeathExplotion;

    public GameObject destination;

    public int ScoreOnDeath;

    public GameObject ShotSpawn;

    public GameObject Ball;

	// Use this for initialization
	void Start () {
        NMA = gameObject.GetComponent<NavMeshAgent>();
        destination = GameObject.Find("Player");
        StartCoroutine(Shoot());
	}
	
	// Update is called once per frame
	void Update () {
        NMA.SetDestination(destination.transform.position);
	}

    public void Dead()
    {
        destination.GetComponent<PlayerController>().TotalScore += ScoreOnDeath;

        Instantiate(DeathExplotion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(.25f, .5f));
        Instantiate(Ball, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
        StartCoroutine(Shoot());
    }
}
