using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject Enemy;

    public Transform EnemySpawn01;
    public Transform EnemySpawn02;
    public Transform EnemySpawn03;
    public Transform EnemySpawn04;

    public float enemySpawnDelay1 = 4f;
    public float enemySpawnDelay2 = 8f;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawn()
    {
        int randSpawn = Random.Range(1,4);

        if (randSpawn == 1)
        {
            Instantiate(Enemy, EnemySpawn01.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(enemySpawnDelay1, enemySpawnDelay2));
            StartCoroutine(Spawn());

        } else if (randSpawn == 2)
        {
            Instantiate(Enemy, EnemySpawn02.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(enemySpawnDelay1, enemySpawnDelay2));
            StartCoroutine(Spawn());

        } else if (randSpawn == 3)
        {
            Instantiate(Enemy, EnemySpawn03.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(enemySpawnDelay1, enemySpawnDelay2));
            StartCoroutine(Spawn());

        } else if (randSpawn == 4)
        {
            Instantiate(Enemy, EnemySpawn04.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(enemySpawnDelay1, enemySpawnDelay2));
            StartCoroutine(Spawn());

        }
    }
}
