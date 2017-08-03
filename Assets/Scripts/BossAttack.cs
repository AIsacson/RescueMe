using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {


	public float timeBetweenAttacks = 1.5f;
	public int attackDamage = 25;

	GameObject player;
	PlayerHealth playerHP;
	BossController bossHP;
	AudioSource attack;
	bool playerInRange;
	float timer;


	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		bossHP = GetComponent<BossController> ();
		playerHP = player.GetComponent<PlayerHealth> ();
		AudioSource [] audio = GetComponents<AudioSource> ();
		attack = audio [0];
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
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange && bossHP.lives > 0) {
			attack.Play ();
			Attack ();
		}
	}

	void Attack(){
		timer = 0;

		if (playerHP.currentHealth > 0) {
			playerHP.TakeDamage (attackDamage);
		}
	}
}
