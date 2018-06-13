using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public float interval;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", 0, interval);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnEnemy()
    {
        Vector3 position = new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40));
        Instantiate(enemy, position, Quaternion.identity);
    }
}
