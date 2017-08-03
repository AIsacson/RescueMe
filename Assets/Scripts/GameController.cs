using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {

	//Spawn positions
	public Transform spawnShipPoint;
	public Transform[] enemySpawningPoints;
	public Transform[] controlPanelSpawningPoints;
	public Transform[] bossSpawningPoints;
	public Transform bulletSpawn;
	//Game objects
	public GameObject ship;
	public GameObject enemy;
	public GameObject cPanel;
	public GameObject boss;
	public GameObject bullet;

	public bool shipHere = false;
	public float spawnTime;

	void Awake () {
		SpawnControl ();
	}

	void Start () {
		InvokeRepeating ("EnemySpawn", 0.5f, spawnTime);
		Invoke("BossSpawn",spawnTime);
	}

	void SpawnControl(){
		int spawnPointIndex = Random.Range (0, controlPanelSpawningPoints.Length);
		if (GameObject.FindGameObjectsWithTag("ControlPanel").Length <= 0) {
			cPanel = Instantiate (cPanel, controlPanelSpawningPoints [spawnPointIndex].position, controlPanelSpawningPoints [spawnPointIndex].rotation);
		}
	}

	void EnemySpawn () {
		int spawnPointIndex = Random.Range (0, enemySpawningPoints.Length);
		if (GameObject.FindGameObjectsWithTag("Enemy").Length < 20) {
			Instantiate (enemy, enemySpawningPoints [spawnPointIndex].position, enemySpawningPoints [spawnPointIndex].rotation);
		}
	}

	void BossSpawn () {

		Instantiate (boss, bossSpawningPoints [0].position, bossSpawningPoints [0].rotation);
		Instantiate (boss, bossSpawningPoints [1].position, bossSpawningPoints [1].rotation);
		Instantiate (boss, bossSpawningPoints [2].position, bossSpawningPoints [2].rotation);
		Instantiate (boss, bossSpawningPoints [3].position, bossSpawningPoints [3].rotation);
	}

	public void ShipSpawn(){
		if (GameObject.FindGameObjectsWithTag ("Ship").Length <= 0) {
			Instantiate (ship, spawnShipPoint.position, spawnShipPoint.rotation);
			shipHere = true;
		}
	}

	public void BulletSpawn(){
		Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
	}
}
