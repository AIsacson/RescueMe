using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 1.5f;
	public int attackDamage = 10;
	public AudioSource gettingHit;

	GameObject player;
	//PlayerPushButton shipIsSpawned;
	AudioSource attack;
	PlayerHealth playerHP;
	//ShipHealth shipHP;
	EnemyMovement enemyLives;
	bool playerInRange;
	float timer;


	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyLives = GetComponent<EnemyMovement> ();
		playerHP = player.GetComponent<PlayerHealth> ();
		//shipHP = FindObjectOfType<ShipHealth> ();
		AudioSource [] audio = GetComponents<AudioSource> ();
		attack = audio [0];
		gettingHit = audio [1];
		//shipIsSpawned = FindObjectOfType<PlayerPushButton> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			playerInRange = false;
		}
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyLives.lives > 0) {
			
			Attack();
		}
	}

	void Attack(){
		timer = 0;
		if (playerHP.currentHealth > 0) {
			playerHP.TakeDamage (attackDamage);
			attack.Play ();
		}
		/*if (shipIsSpawned.shipHere) {
			if (shipHP.currentHealth > 0) {
				shipHP.TakeDamage (attackDamage);
				attack.Play ();
			}
		}*/
	}
}