using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy, clone;
    public Transform enemySpawn;

	// Use this for initialization
	void Start () {
        StartCoroutine(EnemySpawnTimer(2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator EnemySpawnTimer(int enemySpawnTime)
    {
        //enter initial code
        yield return new WaitForSeconds(enemySpawnTime);
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        clone = Instantiate(enemy, enemySpawn);
    }

    
}
