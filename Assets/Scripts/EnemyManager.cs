using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawningPoints;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 10f, spawnTime);
	}

	void Spawn () {
		int spawnPointIndex = Random.Range (0, spawningPoints.Length);
		if (GameObject.FindGameObjectsWithTag("Enemy").Length < 20) {
			Instantiate (enemy, spawningPoints [spawnPointIndex].position, spawningPoints [spawnPointIndex].rotation);
		}
	}
}
