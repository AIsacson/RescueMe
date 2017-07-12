using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 10f;
	public Transform[] spawningPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawningPoints.Length);
		if (GameObject.FindGameObjectsWithTag("Enemy").Length < 5) {
			Instantiate (enemy, spawningPoints [spawnPointIndex].position, spawningPoints [spawnPointIndex].rotation);
		}
	}
}
